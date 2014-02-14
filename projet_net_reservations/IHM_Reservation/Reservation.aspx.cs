﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IHM_Reservation.WebServiceConsultation;
using System.Threading;
using System.Globalization;
using ProjetNet.Modele.ModeleReservation;
using System.Web.Services.Protocols;

namespace IHM_Reservation
{
    public partial class _Default : System.Web.UI.Page
    {
        // initialisation du WS consultation
        private Service1Soap soap = new Service1SoapClient("Service1Soap12");
        private List<HotelWS> hotels = new List<HotelWS>();
        private List<VolWS> vols = new List<VolWS>();
        private List<DestinationWS> destinations = new List<DestinationWS>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try {
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
                lbl_erreurWS.Text = "Un problème est survenu lors de la récupération des "+
                "informations demandées. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }
        }

        protected void btn_valider_voyage_Click(object sender, EventArgs e)
        {
            try
            {
                // info du vol
                Vol vol = new Vol();
                VolWS volSelected = this.vols[Convert.ToInt32(dpdl_volDispo.SelectedValue)];
                vol.Name = volSelected.name;
                vol.Price = Convert.ToDecimal(volSelected.price);
                vol.Category = volSelected.category;
                vol.From = this.destinations[volSelected.id_destination_from].city;
                vol.To = this.destinations[volSelected.id_destination_to].city;

                // info de l'hotel
                Hotel hotel = new Hotel();
                HotelWS hotelSelected = this.hotels[Convert.ToInt32(dpdl_hotelDispo.SelectedValue)];
                hotel.Name = hotelSelected.name;
                hotel.Stars = Convert.ToByte(hotelSelected.stars);
                hotel.Price = hotel.Price;
                hotel.City = this.destinations[hotelSelected.id_destination].city;
                hotel.Country = this.destinations[hotelSelected.id_destination].country;

                // infos du client
                Client client = new Client();
                client.FirstName = txt_clientFirstname.Text;
                client.LastName = txt_clientName.Text;
                client.Mail = txt_clientMail.Text;
                client.Phone = txt_clientPhone.Text;
                client.Address = txt_clientAddress.Text;
                client.PostalCode = txt_clientPostalCode.Text;
                client.City = txt_clientCity.Text;
                client.Country = txt_clientPays.Text;

                // infos de la reservation
                ReservationHotelVol resa = new ReservationHotelVol();
                resa.Client = client;
                resa.Hotel = hotel;
                resa.Vol = vol;
            }
            catch (Exception exception)
            {
                lbl_erreurWS.Text = "Un problème est survenu lors de l'enregistrement de votre "+
                "réservation. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }
        }

        protected void btn_rechercher_Click(object sender, EventArgs e)
        {
            // recuperation des elements de recherchent du formulaire
            int idFrom = int.Parse(dpdl_villeDep.SelectedValue);
            int idTo = int.Parse(dpdl_villeArr.SelectedValue);
            DateTime dateStart = cal_dateStart.SelectedDate;

           
            // *****************************
            // GetListHotels
            // *****************************
            try
            {
                // creation de la requete
                GetListHotelsRequestBody hotelRequestBody = new GetListHotelsRequestBody(idTo);
                GetListHotelsRequest hotelRequest = new GetListHotelsRequest(hotelRequestBody);
                // appel du WS
                GetListHotelsResponse hotelResponse = this.soap.GetListHotels(hotelRequest);
                // reponse du WS
                this.hotels = hotelResponse.Body.GetListHotelsResult;

                foreach (HotelWS h in this.hotels)
                {
                    dpdl_hotelDispo.Items.Add(new ListItem { Text = h.name + " - " + h.stars + "* - " + h.price + " €", Value = h.id.ToString() });
                }
            }
            catch (Exception exception)
            {
                lbl_erreurWS.Text = "Un problème est survenu lors de la récupération des"+
                "hôtels. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;

            }

            // *****************************
            // GetListVols
            // *****************************
            /*
            CultureInfo culture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MMM-dd";
            culture.DateTimeFormat.LongTimePattern = "yyyy-MMM-dd HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            */
            try
            {
            // creation de la requete
            GetListVolsRequestBody volRequestBody = new GetListVolsRequestBody(idFrom, idTo, dateStart);
            GetListVolsRequest volRequest = new GetListVolsRequest(volRequestBody);
            // appel du WS
            GetListVolsResponse volResponse = this.soap.GetListVols(volRequest);
            // reponse du WS
            this.vols = volResponse.Body.GetListVolsResult;

            foreach (VolWS v in this.vols)
            {
                dpdl_volDispo.Items.Add(
                    new ListItem { Text = v.name + " - " + v.category + " - " + v.price + " €", Value = v.id.ToString() });
            }
            }
            catch (Exception exception)
            {
                lbl_erreurWS.Text = "Un problème est survenu lors de la récupération des" +
                "vols. Veuillez réessayer plus tard...";
                lbl_erreurWS.Visible = true;
            }

            panelReservation.Visible = true;
        }
    }
}