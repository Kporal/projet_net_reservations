using ProjetNet.DataAccessL.libResaHotels;
using ProjetNet.DataAccessL.libResaVols;
using ProjetNet.Modele.ModeleReservation;
using System;
using System.EnterpriseServices;

namespace ProjetNet.BusinessL.libReservation
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(), Description("Reservation Hotel & Vol")] 
    public class Reservation : ServicedComponent
    {
        public Reservation ()
        {
        }

        [AutoComplete]
        public void DoReservation(ReservationHotelVol reservation)  
        {
            ReservationHotels resaHotel = new ReservationHotels();
            ReservationVols resaVol = new ReservationVols();

            if (reservation == null)
            {
                throw new ArgumentNullException("Reservation incorrecte", "reservation");
            }
            if(reservation.DateEnd == null || reservation.DateStart == null)
            {
                throw new ArgumentNullException("Dates incorrectes");
            }
            else
            {
                if(reservation.DateStart > reservation.DateEnd)
                {
                    throw new ArgumentException("Dates de début après la date de fin.");
                }
            }
            if(reservation.Hotel == null)
            {
                throw new ArgumentNullException("Hotel incorrect", "hotel");
            }
            if(reservation.Vol == null)
            {
                throw new ArgumentNullException("Vol incorrect", "Vol");
            }

            resaHotel.ReservationHotel(reservation);
            resaVol.ReservationVol(reservation);
        }
    }
}
