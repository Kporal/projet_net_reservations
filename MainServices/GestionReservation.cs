using ProjetNet.Modele.ModeleReservation;
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
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ReservationHotelVol) });

            // Ajoute l'evenement de reception d'un message.
            myQueue.PeekCompleted += new
                PeekCompletedEventHandler(MyPeekCompleted);

            // Lance l'attente asynchrone d'un message.
            myQueue.BeginPeek();
        }

        /// <summary>
        /// Evenement declenché à la reception d'un message.
        /// </summary>
        /// <param name="source">Queue</param>
        /// <param name="asyncResult">Message</param>
        private void MyPeekCompleted(Object source, 
			PeekCompletedEventArgs asyncResult)
		{
			// Récupère la queue.
			MessageQueue mq = (MessageQueue)source;
            System.Diagnostics.Debug.WriteLine("(Info) Reception d'une demande de reservation");
            try
            {
                // Récupération du message.
                ReservationHotelVol reservation = (ReservationHotelVol) mq.EndPeek(asyncResult.AsyncResult).Body;

                
                System.Diagnostics.Debug.Write("(Info) Reservation reussie.");
                // Efface le message.
                mq.Receive();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("(Erreur) Reservation echouée : ");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                // Relance l'attente d'un message.
                mq.BeginPeek();
            }
		}
    }
}
