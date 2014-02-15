using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IHM_Reservation.WebServiceConsultation;
using System.Threading;
using System.Globalization;
using ProjetNet.Modele.ModeleReservation;
using System.Web.Services.Protocols;
using System.Messaging;

namespace IHM_Reservation
{
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// Chemin de la messaging queue.
        /// </summary>
        private const string messageQueuePath = @".\private$\reservation";
        // initialisation du WS consultation
        private Service1Soap soap = new Service1SoapClient("Service1Soap12");
        private List<HotelWS> hotels = new List<HotelWS>();
        private List<VolWS> vols = new List<VolWS>();
        private List<DestinationWS> destinations = new List<DestinationWS>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // test si la page est rendu pour la premiere fois
                if (!IsPostBack)
                {
                    // *****************************
                    // GetListDestination
                    // *****************************

                    // creation de la requete
                    GetListDestinationsRequest destinationRequest = new GetListDestinationsRequest(new GetListDestinationsRequestBody());
                    // appel du WS
                    GetListDestinationsResponse destinationResponse = this.soap.GetListDestinations(destinationRequest);
                    // reponse du WS
                    this.destinations = destinationResponse.Body.GetListDestinationsResult;

                    // insertion des destinations dans les listes
                    foreach (DestinationWS d in this.destinations)
                    {
                        dpdl_villeDep.Items.Add(new ListItem { Text = d.city + ", " + d.country, Value = d.id.ToString() });
                        dpdl_villeArr.Items.Add(new ListItem { Text = d.city + ", " + d.country, Value = d.id.ToString() });
                    }
                }
            }
            catch (Exception soapException)
            {
                btn_rechercher.Enabled = false;
                lbl_erreurWS.Text = "Un problème est survenu lors de la récupération des " +
                "informations demandées. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }
        }

        protected void btn_valider_voyage_Click(object sender, EventArgs e)
        {
            // Création de la queue.
            MessageQueue msgQ = new MessageQueue(messageQueuePath);
            // Rends les messages récupérables en cas de crash.
            msgQ.DefaultPropertiesToSend.Recoverable = true;

            try
            {
                // Envois du message.
                msgQ.Send(new ReservationHotelVol()
                    {
                        Client = getClientSelected(),
                        Hotel = getHotelSelected(),
                        Vol = getVolSelected(),
                        DateEnd = this.cal_dateEnd.SelectedDate,
                        DateStart = this.cal_dateStart.SelectedDate
                    }, "Message de reservation");
            }
            catch (Exception exception)
            {
                lbl_erreurWS.Text = "Un problème est survenu lors de l'enregistrement de votre " +
                "réservation. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }
            finally
            {
                msgQ.Close();
            }
        }

        protected void btn_rechercher_Click(object sender, EventArgs e)
        {
            try
            {
                // recuperation des elements de recherchent du formulaire
                int idFrom = int.Parse(dpdl_villeDep.SelectedValue);
                int idTo = int.Parse(dpdl_villeArr.SelectedValue);
                DateTime dateStart = cal_dateStart.SelectedDate;
                panelReservation.Visible = true;
                btn_valider_voyage.Enabled = true;

                // *****************************
                // GetListHotels
                // *****************************
                getListHotels(idTo);

                // *****************************
                // GetListVols
                // *****************************
                getListVols(idFrom, idTo, dateStart);
            }
            catch (Exception exception)
            {
                panelReservation.Visible = false;
                btn_valider_voyage.Enabled = false;
            }
        }

        protected void dpdl_volDispo_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDetailVol(this.vols[Convert.ToInt32(dpdl_volDispo.SelectedValue)]);
        }

        protected void dpdl_hotelDispo_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDetailHotel(this.hotels[Convert.ToInt32(dpdl_hotelDispo.SelectedValue)]);
        }

        private void getListVols(int idFrom, int idTo, DateTime dateStart)
        {
            try
            {
                // creation de la requete
                GetListVolsRequestBody volRequestBody = new GetListVolsRequestBody(idFrom, idTo, dateStart);
                GetListVolsRequest volRequest = new GetListVolsRequest(volRequestBody);
                // appel du WS
                GetListVolsResponse volResponse = this.soap.GetListVols(volRequest);
                // reponse du WS
                this.vols = volResponse.Body.GetListVolsResult;

                // insertion des vols dans la liste
                foreach (VolWS v in this.vols)
                {
                    dpdl_volDispo.Items.Add(
                        new ListItem { Text = v.name + " - " + v.category + " - " + v.price + " €", Value = v.id.ToString() });
                }
                setDetailVol(this.vols[0]);
            }
            catch (Exception exception)
            {
                btn_valider_voyage.Enabled = false;
                panelReservation.Visible = false;
                lbl_erreurWS.Text = "Un problème est survenu lors de la récupération des " +
                "vols. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }
        }

        private void getListHotels(int idTo)
        {
            try
            {
                // creation de la requete
                GetListHotelsRequestBody hotelRequestBody = new GetListHotelsRequestBody(idTo);
                GetListHotelsRequest hotelRequest = new GetListHotelsRequest(hotelRequestBody);
                // appel du WS
                GetListHotelsResponse hotelResponse = this.soap.GetListHotels(hotelRequest);
                // reponse du WS
                this.hotels = hotelResponse.Body.GetListHotelsResult;

                // insertion des hotels dans la liste
                foreach (HotelWS h in this.hotels)
                {
                    dpdl_hotelDispo.Items.Add(new ListItem { Text = h.name + " - " + h.stars + "* - " + h.price + " €", Value = h.id.ToString() });
                }
                setDetailHotel(this.hotels[0]);
            }
            catch (Exception exception)
            {
                btn_valider_voyage.Enabled = false;
                panelReservation.Visible = false;
                lbl_erreurWS.Text = "Un problème est survenu lors de la récupération des " +
                "hôtels. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }
        }

        private Hotel getHotelSelected()
        {
            // info de l'hotel
            Hotel hotel = new Hotel();
            HotelWS hotelSelected = this.hotels[Convert.ToInt32(dpdl_hotelDispo.SelectedValue)];
            hotel.Name = hotelSelected.name;
            hotel.Stars = Convert.ToByte(hotelSelected.stars);
            hotel.Price = hotel.Price;
            hotel.City = getDestinationById(hotelSelected.id_destination).city;
            hotel.Country = getDestinationById(hotelSelected.id_destination).country;
            return hotel;
        }

        private Vol getVolSelected()
        {
            // info du vol
            Vol vol = new Vol();
            VolWS volSelected = this.vols[Convert.ToInt32(dpdl_volDispo.SelectedValue)];
            vol.Name = volSelected.name;
            vol.Price = Convert.ToDecimal(volSelected.price);
            vol.Category = volSelected.category;
            vol.From = getDestinationById(volSelected.id_destination_from).city;
            vol.To = getDestinationById(volSelected.id_destination_to).city;
            return vol;
        }

        private Client getClientSelected()
        {
            // info du client
            Client client = new Client();
            client.FirstName = txt_clientFirstname.Text;
            client.LastName = txt_clientName.Text;
            client.Mail = txt_clientMail.Text;
            client.Phone = txt_clientPhone.Text;
            client.Address = txt_clientAddress.Text;
            client.PostalCode = txt_clientPostalCode.Text;
            client.City = txt_clientCity.Text;
            client.Country = txt_clientPays.Text;
            return client;
        }

        private void setDetailVol(VolWS vol)
        {
            lbl_vol_category.Text = vol.category;
            lbl_vol_dateStart.Text = vol.dateStart.ToString();
            lbl_vol_dateEnd.Text = vol.dateEnd.ToString();
            lbl_vol_from.Text = getDestinationById(vol.id_destination_from).city;
            lbl_vol_to.Text = getDestinationById(vol.id_destination_to).city;
            lbl_vol_price.Text = vol.price.ToString();
        }

        private void setDetailHotel(HotelWS hotel)
        {
            lbl_hotel_stars.Text = hotel.stars.ToString();
            lbl_hotel_price.Text = hotel.price.ToString();
            lbl_hotel_name.Text = hotel.name;
            lbl_hotel_city.Text = getDestinationById(hotel.id_destination).city;
            lbl_hotel_country.Text = getDestinationById(hotel.id_destination).country;
        }

        private DestinationWS getDestinationById(int idDestination)
        {
            foreach (DestinationWS dest in this.destinations)
            {
                if (dest.id == idDestination)
                {
                    return dest;
                }
            }
            return new DestinationWS();
        }

    }
}