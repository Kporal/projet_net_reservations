using ProjetNet.Modele.ModeleReservation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNet.DataAccessL.libResaVols
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(), System.EnterpriseServices.Description("Reservation Vols")]
    public class ReservationVols : ServicedComponent
    {
        public ReservationVols()
        {
        }

        [AutoComplete]
        public void ReservationHotel(ReservationHotelVol reservation)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=cmd_vols; Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("insertCmdVols", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;

            // Client
            MyCom.Parameters.Add("@FirstName", SqlDbType.VarChar);
            MyCom.Parameters["@FirstName"].Value = reservation.Client.FirstName;
            MyCom.Parameters.Add("@LastName", SqlDbType.VarChar);
            MyCom.Parameters["@LastName"].Value = reservation.Client.LastName;
            MyCom.Parameters.Add("@Address", SqlDbType.VarChar);
            MyCom.Parameters["@Address"].Value = reservation.Client.Address;
            MyCom.Parameters.Add("@PostalCode", SqlDbType.VarChar);
            MyCom.Parameters["@PostalCode"].Value = reservation.Client.PostalCode;
            MyCom.Parameters.Add("@City", SqlDbType.VarChar);
            MyCom.Parameters["@City"].Value = reservation.Client.City;
            MyCom.Parameters.Add("@Country", SqlDbType.VarChar);
            MyCom.Parameters["@Country"].Value = reservation.Client.Country;

            // Vols
            MyCom.Parameters.Add("@Vols_name", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_name"].Value = reservation.Vol.Name;
            MyCom.Parameters.Add("@Vols_from", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_from"].Value = reservation.Vol.From;
            MyCom.Parameters.Add("@Vols_to", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_to"].Value = reservation.Vol.To;
            MyCom.Parameters.Add("@Vols_category", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_category"].Value = reservation.Vol.Category;
            MyCom.Parameters.Add("@Vols_DateStart", SqlDbType.DateTime);
            MyCom.Parameters["@Vols_DateStart"].Value = reservation.DateStart;
            MyCom.Parameters.Add("@Vols_DateEnd", SqlDbType.DateTime);
            MyCom.Parameters["@Vols_DateEnd"].Value = reservation.DateEnd;
            MyCom.Parameters.Add("@Vols_Price", SqlDbType.Money);
            MyCom.Parameters["@Vols_Price"].Value = reservation.Vol.Price;

            int Res = Convert.ToInt32(MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
        }
    }
}
