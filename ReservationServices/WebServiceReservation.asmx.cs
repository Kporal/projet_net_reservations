using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProjetNet.Reservation.ReservationServices.ReservationServices
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
        public void Reserver(string FirstName, string LastName, string Address, string PostalCode, string City, string Country, 
            string Stars, string CityHotel, string CountryHotel, string HotelPrice, string HotelDateStart, string HotelDateEnd,
            string VolName, string VolFrom, string VolTo, string VolCategory, string VolPrice, string VolDateStart, string VolDateEnd)
        {
            Reservation.ReservationBL.libReservation.Reservation resa = new ProjetNet.Reservation.ReservationBL.libReservation.Reservation();
            resa.DoReservation(FirstName, LastName, Address, PostalCode, City, Country, 
                Stars, CityHotel, CountryHotel, HotelPrice, HotelDateStart, HotelDateEnd, 
                VolName, VolFrom, VolTo, VolCategory, VolPrice, VolDateStart, VolDateEnd);
        }
    }
}
