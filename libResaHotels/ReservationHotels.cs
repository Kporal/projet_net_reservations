using ProjetNet.Modele.ModeleReservation;
using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;

namespace ProjetNet.DataAccessL.libResaHotels
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled(), System.EnterpriseServices.Description("Reservation Hotel")]
    public class ReservationHotels : ServicedComponent
    {
        public ReservationHotels()
        {
        }

        [AutoComplete]
        public void ReservationHotel(ReservationHotelVol reservation)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=cmd_hotels; Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("insertCmdHotels", MyC);
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

            // hotel
            MyCom.Parameters.Add("@Hotels_Stars", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_Stars"].Value = reservation.Hotel.Stars;
            MyCom.Parameters.Add("@Hotels_City", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_City"].Value = reservation.Hotel.City;
            MyCom.Parameters.Add("@Hotels_Country", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_Country"].Value = reservation.Hotel.Country;
            MyCom.Parameters.Add("@Hotels_Price", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_Price"].Value = reservation.Hotel.Price;
            MyCom.Parameters.Add("@Hotels_dateStart", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_dateStart"].Value = reservation.DateStart;
            MyCom.Parameters.Add("@Hotels_dateEnd", SqlDbType.VarChar);
            MyCom.Parameters["@Hotels_dateEnd"].Value = reservation.DateEnd;

            int Res = Convert.ToInt32 (MyCom.ExecuteScalar());
            MyCom.Dispose();
            MyC.Close();
        }
    }
}
