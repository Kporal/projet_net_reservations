using ProjetNet.Reservation.ReservationDAL.libResaHotels;
using ProjetNet.Reservation.ReservationDAL.libResaVols;
using System.EnterpriseServices;

namespace ProjetNet.Reservation.ReservationBL.libReservation
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(), Description("Reservation Hotel & Vol")] 
    public class Reservation : ServicedComponent
    {
        public Reservation ()
        {
        }

        [AutoComplete ]
        public void DoReservation(string FirstName, string LastName, string Address, string PostalCode, string City, string Country, 
            string Stars, string CityHotel, string CountryHotel, string HotelPrice, string HotelDateStart, string HotelDateEnd,
            string VolName, string VolFrom, string VolTo, string VolCategory, string VolPrice, string VolDateStart, string VolDateEnd)  
        {
            ReservationHotels resaHotel = new ReservationHotels();
            ReservationVols resaVol = new ReservationVols();

            resaHotel.ReservationHotel(FirstName, LastName, Address, PostalCode, City, Country, 
                Stars, CityHotel, CountryHotel, HotelPrice, HotelDateStart, HotelDateEnd);
            resaVol.ReservationHotel(FirstName, LastName, Address, PostalCode, City, Country, 
                VolName, VolFrom, VolTo, VolCategory, VolPrice, VolDateStart, VolDateEnd);
        }
    }
}
