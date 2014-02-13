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
        public void ReservationHotel(string FirstName, string LastName, string Address, string PostalCode, string City, string Country, string VolName, string VolFrom, string VolTo, string VolCategory, string Price, string dateStart, string dateEnd)
        {

            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=cmd_vols; Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("insertCmdVols", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;

            // Client
            MyCom.Parameters.Add("@FirstName", SqlDbType.VarChar);
            MyCom.Parameters["@FirstName"].Value = FirstName;
            MyCom.Parameters.Add("@LastName", SqlDbType.VarChar);
            MyCom.Parameters["@LastName"].Value = LastName;
            MyCom.Parameters.Add("@Address", SqlDbType.VarChar);
            MyCom.Parameters["@Address"].Value = Address;
            MyCom.Parameters.Add("@PostalCode", SqlDbType.VarChar);
            MyCom.Parameters["@PostalCode"].Value = PostalCode;
            MyCom.Parameters.Add("@City", SqlDbType.VarChar);
            MyCom.Parameters["@City"].Value = City;
            MyCom.Parameters.Add("@Country", SqlDbType.VarChar);
            MyCom.Parameters["@Country"].Value = Country;

            // Vols
            MyCom.Parameters.Add("@Vols_name", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_name"].Value = VolName;
            MyCom.Parameters.Add("@Vols_from", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_from"].Value = VolFrom;
            MyCom.Parameters.Add("@Vols_to", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_to"].Value = VolTo;
            MyCom.Parameters.Add("@Vols_category", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_category"].Value = VolCategory;
            MyCom.Parameters.Add("@Vols_DateStart", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_DateStart"].Value = dateStart;
            MyCom.Parameters.Add("@Vols_DateEnd", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_DateEnd"].Value = dateEnd;
            MyCom.Parameters.Add("@Vols_Price", SqlDbType.VarChar);
            MyCom.Parameters["@Vols_Price"].Value = Price;

            int Res = Convert.ToInt32(MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
        }
    }
}
