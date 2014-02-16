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
    [Serializable]
    public class Hotel
    {
        public Hotel() { }

        /// <summary>
        /// Nom.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Etoiles.
        /// </summary>
        public byte Stars { get; set;  }

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
        public decimal Price { get; set; }
    }
}
