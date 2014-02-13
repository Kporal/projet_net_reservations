using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IHM_Reservation.WebServiceConsultation;

namespace IHM_Reservation
{
    public partial class _Default : System.Web.UI.Page
    {
        private List<Hotel> hotels;
        private List<Vol> vols;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_valider_voyage_Click(object sender, EventArgs e)
        {

        }

        protected void btn_rechercher_Click(object sender, EventArgs e)
        {
            // recuperation des elements de recherchent du formulaire
            string from = dpdl_villeDep.SelectedValue;
            string to = dpdl_villeArr.SelectedValue;

            // initialisation du WS consultation
            Service1Soap soap = new Service1SoapClient("Service1Soap12");

            // *****************************
            // GetListHotels
            // *****************************

            // creation de la requete
            
            GetListHotelsRequestBody requestBody = new GetListHotelsRequestBody(to);
            GetListHotelsRequest request = new GetListHotelsRequest(requestBody);
            // appel du WS
            GetListHotelsResponse response = soap.GetListHotels(request);
            // reponse du WS
            this.hotels = response.Body.GetListHotelsResult;

            foreach (Hotel h in hotels) {
                //dpdl_volDispo.Items.Add(new { Text = "report A", Value = "reportA" });
            }
            
            panelReservation.Visible = true;
        }
    }
}