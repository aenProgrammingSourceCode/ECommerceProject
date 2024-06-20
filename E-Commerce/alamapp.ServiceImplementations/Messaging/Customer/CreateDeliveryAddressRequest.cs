using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class CreateDeliveryAddressRequest
    {
        public int CustomerId { get; set; }
        public int DistrictId { get; set; }
        public int PoliceStationId { get; set; }
        public string CompanyName { get; set; }
        public string OfficeOrHome { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
    }
}
