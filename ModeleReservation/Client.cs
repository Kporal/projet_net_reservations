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
    [Serializable]
    public class Client
    {
        public Client() { }

        /// <summary>
        /// Prénom.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nom.
        /// </summary>
        public string LastName { get; set;  }

        /// <summary>
        /// Mail.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Telephone.
        /// </summary>
        public string Phone { get; set; }

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
