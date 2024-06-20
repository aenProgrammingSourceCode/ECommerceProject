using alamapp.ServiceImplementations.ViewModel.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Messaging.Customer
{
   public class CreateCustomerRequest
    {
        public CreateCustomerRequest()
        {
            DeliveryAddresses = new List<DeliveryAddressView>();
        }
        public string IdentityToken { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public string UserName { get; set; }
        public IEnumerable<DeliveryAddressView> DeliveryAddresses { get; set; }
    }
}
