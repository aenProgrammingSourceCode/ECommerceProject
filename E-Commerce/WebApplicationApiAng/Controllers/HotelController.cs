using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationApiAng.Models;

namespace WebApplicationApiAng.Controllers
{
    public class HotelController : ApiController
    {
        private List<HotelViewModel> _Hotels = new List<HotelViewModel>()
        {
            new HotelViewModel(){ Id=1, Name="Cox Today", Type="5 Star", Location="Cox Bazar"},
            new HotelViewModel(){ Id=2, Name="Peninsula", Type="3 Star", Location="Chittagong"},
            new HotelViewModel(){ Id=3, Name="Redison", Type="5 Star", Location="Chittagong"},
            new HotelViewModel(){ Id=4, Name="Sheraton", Type="5 Star", Location="Dhaka"}
        };
        public HttpResponseMessage GetAllData()
        {
            IEnumerable<HotelViewModel> GetHotels = _Hotels.ToList();
            HttpResponseMessage httpResponse = Request.CreateResponse(HttpStatusCode.OK, GetHotels);
            return httpResponse;
        }
    }
}
