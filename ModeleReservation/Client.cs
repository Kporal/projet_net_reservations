using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.Modele.ModeleReservation
{
    /// <summary>
    /// Client effectuant la reservation.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Prénom.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nom.
        /// </summary>
        public string LastName { get; set;  }

        /// <summary>
        /// Adresse.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Code postal.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Ville.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Pays.
        /// </summary>
        public string Country { get; set; }
    }
}
