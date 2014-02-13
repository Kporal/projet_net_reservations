﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IHM_Reservation.WebServiceConsultation;
using System.Threading;
using System.Globalization;
using ProjetNet.Modele.ModeleReservation;

namespace IHM_Reservation
{
    public partial class _Default : System.Web.UI.Page
    {
        // initialisation du WS consultation
        private Service1Soap soap = new Service1SoapClient("Service1Soap12");
        private List<IHM_Reservation.WebServiceConsultation.Hotel> hotels = new List<IHM_Reservation.WebServiceConsultation.Hotel>();
        private List<IHM_Reservation.WebServiceConsultation.Vol> vols = new List<IHM_Reservation.WebServiceConsultation.Vol>();
        private List<Destination> destinations = new List<Destination>();

        protected void Page_Load(object sender, EventArgs e)
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

                foreach (Destination d in this.destinations)
                {
                    dpdl_villeDep.Items.Add(new ListItem { Text = d.city + ", " + d.country, Value = d.id.ToString() });
                    dpdl_villeArr.Items.Add(new ListItem { Text = d.city + ", " + d.country, Value = d.id.ToString() });
                }
            }
        }

        protected void btn_valider_voyage_Click(object sender, EventArgs e)
        {
            
            ReservationHotelVol resa = new ReservationHotelVol();
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

            // creation de la requete
            GetListHotelsRequestBody hotelRequestBody = new GetListHotelsRequestBody(idTo);
            GetListHotelsRequest hotelRequest = new GetListHotelsRequest(hotelRequestBody);
            // appel du WS
            GetListHotelsResponse hotelResponse = this.soap.GetListHotels(hotelRequest);
            // reponse du WS
            this.hotels = hotelResponse.Body.GetListHotelsResult;

            foreach (IHM_Reservation.WebServiceConsultation.Hotel h in this.hotels)
            {
                dpdl_hotelDispo.Items.Add(new ListItem { Text = h.name + " - " + h.stars + "* - " + h.price + " €", Value = h.id.ToString() });
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

            // creation de la requete
            GetListVolsRequestBody volRequestBody = new GetListVolsRequestBody(idFrom, idTo, dateStart);
            GetListVolsRequest volRequest = new GetListVolsRequest(volRequestBody);
            // appel du WS
            GetListVolsResponse volResponse = this.soap.GetListVols(volRequest);
            // reponse du WS
            this.vols = volResponse.Body.GetListVolsResult;

            foreach (IHM_Reservation.WebServiceConsultation.Vol v in this.vols)
            {
                dpdl_volDispo.Items.Add(
                    new ListItem { Text = v.name + " - " + v.category + " - " + v.price + " €", Value = v.id.ToString() });
            }

            panelReservation.Visible = true;
        }
    }
}