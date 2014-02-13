using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.Modele.ModeleReservation
{
    /// <summary>
    /// Reservation d'un vol.
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// Nom du vol.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Destination.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Origine.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Categorie de vol.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Prix du vol.
        /// </summary>
        public string Price { get; set; }
    }
}
