using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.Modele.ModeleReservation
{
    /// <summary>
    /// Hotel de la reservation.
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// Etoiles.
        /// </summary>
        public string Stars { get; set;  }

        /// <summary>
        /// Ville.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Pays.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Prix.
        /// </summary>
        public string Price { get; set; }
    }
}
