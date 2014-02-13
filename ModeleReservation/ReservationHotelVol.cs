using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.Modele.ModeleReservation
{
    /// <summary>
    /// Reservation d'un hotel et d'un vol.
    /// </summary>
    public class ReservationHotelVol
    {
        /// <summary>
        /// Client de la reservation.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Hotel de la reservation.
        /// </summary>
        public Hotel Hotel { get; set; }

        /// <summary>
        /// Vol de la resrvation.
        /// </summary>
        public Vol Vol { get; set; }

        /// <summary>
        /// Date de départ.
        /// </summary>
        public string DateStart { get; set; }

        /// <summary>
        /// Date de retour.
        /// </summary>
        public string DateEnd { get; set; }
    }
}
