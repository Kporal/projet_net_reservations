using ProjetNet.DataAccessL.libResaHotels;
using ProjetNet.DataAccessL.libResaVols;
using ProjetNet.Modele.ModeleReservation;
using System.EnterpriseServices;

namespace ProjetNet.BusinessL.libReservation
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(), Description("Reservation Hotel & Vol")] 
    public class Reservation : ServicedComponent
    {
        public Reservation ()
        {
        }

        [AutoComplete ]
        public void DoReservation(ReservationHotelVol reservation)  
        {
            ReservationHotels resaHotel = new ReservationHotels();
            ReservationVols resaVol = new ReservationVols();

            resaHotel.ReservationHotel(reservation);
            resaVol.ReservationHotel(reservation);
        }
    }
}
