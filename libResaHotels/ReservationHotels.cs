using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.Reservation.ReservationDAL.libResaHotels
{
    public partial class ReservationHotels : Component
    {
        public ReservationHotels()
        {
            InitializeComponent();
        }

        public ReservationHotels(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
