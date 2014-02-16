using ProjetNet.Modele.ModeleReservation;
using ProjetNet.Services.MainServices.WebServiceReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.Services.MainServices
{
    /// <summary>
    /// Gestion de la reservation.
    /// </summary>
    public class GestionReservation
    {
        /// <summary>
        /// Chemin d'acces à la queue.
        /// </summary>
        private const string QueuePath = @".\private$\reservation";

        public GestionReservation()
        {
            System.Diagnostics.Debug.WriteLine("(Info) Lancement du service de Gestion des reservations.");
            // Créé la queue de messages et son formateur.
            MessageQueue myQueue = new MessageQueue(QueuePath);
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ProjetNet.Modele.ModeleReservation.ReservationHotelVol) });

            // Ajoute l'evenement de reception d'un message.
            myQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MyPeekCompleted);

            // Lance l'attente asynchrone d'un message.
            myQueue.BeginReceive();
        }

        /// <summary>
        /// Evenement declenché à la reception d'un message.
        /// </summary>
        /// <param name="source">Queue</param>
        /// <param name="asyncResult">Message</param>
        private void MyPeekCompleted(Object source, 
			ReceiveCompletedEventArgs asyncResult)
		{
			// Récupère la queue.
			MessageQueue mq = (MessageQueue)source;
            System.Diagnostics.Debug.WriteLine("(Info) Reception d'une demande de reservation");
            try
            {
                // Récupération du message.
                ProjetNet.Modele.ModeleReservation.ReservationHotelVol reservation = (ProjetNet.Modele.ModeleReservation.ReservationHotelVol) mq.EndPeek(asyncResult.AsyncResult).Body;

                WebServiceReservationSoap serviceReservationSOAP = new WebServiceReservationSoapClient();
                ReserverRequestBody requestBody = new ReserverRequestBody(new WebServiceReservation.ReservationHotelVol()
                    {
                        Client = new WebServiceReservation.Client() {
                            FirstName = reservation.Client.FirstName,
                            LastName = reservation.Client.LastName,
                            Mail = reservation.Client.Mail,
                            Phone = reservation.Client.Phone,
                            Address = reservation.Client.Address,
                            City = reservation.Client.City,
                            PostalCode = reservation.Client.PostalCode,
                            Country = reservation.Client.Country
                        },
                        Hotel = new WebServiceReservation.Hotel() {
                            Name = reservation.Hotel.Name,
                            Stars = reservation.Hotel.Stars,
                            Price = reservation.Hotel.Price,
                            City = reservation.Hotel.City,
                            Country = reservation.Hotel.Country
                        },
                        Vol = new WebServiceReservation.Vol() {
                            Name = reservation.Vol.Name,
                            From = reservation.Vol.From,
                            To = reservation.Vol.To,
                            Price = reservation.Vol.Price,
                            Category = reservation.Vol.Category
                        },
                        DateEnd = reservation.DateEnd,
                        DateStart = reservation.DateStart
                    });
                ReserverRequest reserverRequest = new ReserverRequest(requestBody);

                // appel du WS
                serviceReservationSOAP.Reserver(reserverRequest);
                
                System.Diagnostics.Debug.Write("(Info) Reservation reussie.");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("(Erreur) Reservation echouée : ");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                // Relance l'attente d'un message.
                mq.BeginReceive();
            }
		}
    }
}
