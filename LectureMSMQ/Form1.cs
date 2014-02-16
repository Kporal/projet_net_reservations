using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;
using LectureMSMQ.WebServiceReservation;

namespace LectureMSMQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_LectureMSMQ_Click(object sender, EventArgs e)
        {
            // ouverture de le file MSMQ
            MessageQueue MyMQ = new MessageQueue(@".\private$\reservation");
            // recup sans vider la file d'un message
            MyMQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(ProjetNet.Modele.ModeleReservation.ReservationHotelVol) });

            System.Diagnostics.Debug.WriteLine("(Info) Reception d'une demande de reservation");
            try
            {
                var message = (ProjetNet.Modele.ModeleReservation.ReservationHotelVol)MyMQ.Peek().Body;

                System.Diagnostics.Debug.WriteLine("(Info) Test client: " + message.Client.LastName + "\n"
                    + message.Client.FirstName + "\n" + message.Client.Phone + "\n" + message.Client.Mail + "\n"
                    + message.Client.Address + "\n" + message.Client.PostalCode + "\n" + message.Client.City + "\n"
                    + message.Client.Country);
                System.Diagnostics.Debug.WriteLine("(Info) Test Hotel: " + message.Hotel.Name + "\n"
                    + message.Hotel.Stars + "\n" + message.Hotel.Price + "\n" + message.Hotel.City + "\n"
                    + message.Hotel.Country);
                System.Diagnostics.Debug.WriteLine("(Info) Test Vol: " + message.Vol.Name + "\n"
                    + message.Vol.Category + "\n" + message.Vol.Price + "\n" + message.Vol.From + "\n"
                    + message.Vol.To);

                WebServiceReservationSoap serviceReservationSOAP = new WebServiceReservationSoapClient();
                ReserverRequestBody requestBody = new ReserverRequestBody(new WebServiceReservation.ReservationHotelVol()
                {
                    Client = new WebServiceReservation.Client()
                    {
                        FirstName = message.Client.FirstName,
                        LastName = message.Client.LastName,
                        Mail = message.Client.Mail,
                        Phone = message.Client.Phone,
                        Address = message.Client.Address,
                        City = message.Client.City,
                        PostalCode = message.Client.PostalCode,
                        Country = message.Client.Country
                    },
                    Hotel = new WebServiceReservation.Hotel()
                    {
                        Name = message.Hotel.Name,
                        Stars = message.Hotel.Stars,
                        Price = message.Hotel.Price,
                        City = message.Hotel.City,
                        Country = message.Hotel.Country
                    },
                    Vol = new WebServiceReservation.Vol()
                    {
                        Name = message.Vol.Name,
                        From = message.Vol.From,
                        To = message.Vol.To,
                        Price = message.Vol.Price,
                        Category = message.Vol.Category
                    },
                    DateEnd = message.DateEnd,
                    DateStart = message.DateStart
                });
                ReserverRequest reserverRequest = new ReserverRequest(requestBody);

                // appel du WS
                serviceReservationSOAP.Reserver(reserverRequest);

                System.Diagnostics.Debug.Write("(Info) Reservation reussie.");
                // Cloture l'attente d'un message
                MyMQ.Receive();
                MyMQ.Close();
            }
            catch (Exception excep)
            {
                System.Diagnostics.Debug.WriteLine("(Erreur) Reservation echouée : ");
                System.Diagnostics.Debug.WriteLine(excep.Message);
            }
        }
    }
}
