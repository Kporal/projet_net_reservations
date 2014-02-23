using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace WebService1
{
    /// <summary>
    /// Description résumée de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<HotelWS> GetListHotels(int idCity)
        {
            List<HotelWS> mesHotels = new List<HotelWS>();
            return mesHotels;
        }

        [WebMethod]
        public HotelWS GetHotelById(int id)
        {
            HotelWS h = new HotelWS();
            return h;
        }

        [WebMethod]
        public List<VolWS> GetListVols(int idFrom, int idTo, DateTime dateStart)
        {
            List<VolWS> mesVols = new List<VolWS>();
            return mesVols;
        }

        [WebMethod]
        public VolWS GetVolById(int id)
        {
            return new VolWS();
        }

        [WebMethod]
        public List<DestinationWS> GetListDestinations()
        {
            List<DestinationWS> mesDestinations = new List<DestinationWS>();
            return mesDestinations;
        }
    }

    public class HotelWS
    {
        public int id;
        public string name;
        public int stars;
        public double price;
        public int id_destination;
    }

    public class VolWS
    {
        public int id;
        public string name;
        public double price;
        public string category;
        public string dateStart;
        public string dateEnd;
        public int id_destination_from;
        public int id_destination_to;
    }

    public class DestinationWS
    {
        public int id;
        public string city;
        public string country;
    }
}