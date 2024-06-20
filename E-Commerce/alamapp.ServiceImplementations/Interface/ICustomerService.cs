using alamapp.ServiceImplementations.Messaging.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
   public interface ICustomerService
    {
       CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);
       GetCustomerByIdentityTokenResponse GetByIdentityToken(GetCustomerByIdentityTokenRequest request);
       void CreateDeliveryAddress(CreateDeliveryAddressRequest request);
       GetAllDistrictResponse GetAllDistricts();
       GetAllPoliceStationResponse GetAllPoliceStations();
    }
}
