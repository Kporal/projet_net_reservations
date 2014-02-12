using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;

namespace ProjetNet.Reservation.ReservationDAL.libResaHotels
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(), System.EnterpriseServices.Description("Reservation Hotel")]
    public class ReservationHotels : ServicedComponent
    {
        public ReservationHotels()
        {
        }

        [AutoComplete]
        public void ReservationHotel(string FirstName, string LastName, string Address, string PostalCode, string City, string Country, string Stars, string CityHotel, string CountryHotel, string Price, string dateStart, string dateEnd){
        
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local); Initial Catalog=cmd_hotels; Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("insertCmdHotels", MyC);
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

            // hotel
            MyCom.Parameters.Add("@Hotels_Stars", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_Stars"].Value = Stars;
            MyCom.Parameters.Add("@Hotels_City", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_City"].Value = CityHotel;
            MyCom.Parameters.Add("@Hotels_Country", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_Country"].Value = CountryHotel;
            MyCom.Parameters.Add("@Hotels_Price", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_Price"].Value = Price;
            MyCom.Parameters.Add("@Hotels_dateStart", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_dateStart"].Value = dateStart;
            MyCom.Parameters.Add("@Hotels_dateEnd", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_dateEnd"].Value = dateStart;

            int Res = Convert.ToInt32 (MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
        }
    }
}
