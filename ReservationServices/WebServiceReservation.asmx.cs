using ProjetNet.BusinessL.libReservation;
using ProjetNet.Modele.ModeleReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProjetNet.Services.ReservationServices
{
    /// <summary>
    /// Service de reservation.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceReservation : System.Web.Services.WebService
    {
        [WebMethod]
        public void Reserver(ReservationHotelVol reservation)
        {
            Reservation resa = new Reservation();
            resa.DoReservation(reservation);
        }
    }
}
