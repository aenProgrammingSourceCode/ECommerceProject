using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Customers
{
   public class DeliveryAddressView
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string ZipCode { get; set; }
        public string OfficeOrHome { get; set; }
        public string DistrictName { get; set; }
        public string PoliceStationName { get; set; }
        public string CompanyName { get; set; }
    }
}
