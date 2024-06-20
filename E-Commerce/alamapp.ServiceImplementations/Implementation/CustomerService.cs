using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Customers;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Customers;
using alamapp.ServiceImplementations.Interface;
using alamapp.ServiceImplementations.Mapping;
using alamapp.ServiceImplementations.Messaging.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class CustomerService:ICustomerService
    {
       private ICustomerRepository _customerRepository;
       private IDeliveryAddressRepository _deliveryAddressRepository;
       private IDistrictRepository _districtRepository;
       private IPoliceStationRepository _policeStationRepository;

       private IUnitOfWork _uow;
       public CustomerService(ICustomerRepository customerRepository, IDistrictRepository districtRepository, IPoliceStationRepository policeStationRepository,IDeliveryAddressRepository deliveryAddressRepository,
           IUnitOfWork uow)
       {
           _districtRepository = districtRepository;
           _policeStationRepository = policeStationRepository;
           _uow = uow;
           _customerRepository = customerRepository;
           _deliveryAddressRepository = deliveryAddressRepository;
       }
        public CreateCustomerResponse CreateCustomer(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new CreateCustomerResponse();

            Customer customer = new Customer();
            customer.UserName = request.UserName;
            customer.Country = request.Country;
            customer.DateOfBirth = request.DateOfBirth;
            customer.Gender = request.Gender;
            customer.MobileNo = request.MobileNo;
            customer.IdentityToken = request.IdentityToken;
            response.Customer = customer.ConvertToCustomerView();
            _customerRepository.Add(customer);

            _uow.Commit();
            return response;
        }


        public GetCustomerByIdentityTokenResponse GetByIdentityToken(GetCustomerByIdentityTokenRequest request)
        {
            Customer customer = _customerRepository.FindBy(request.IdentityToken);
            GetCustomerByIdentityTokenResponse response = new GetCustomerByIdentityTokenResponse();
            response.Customer = customer.ConvertToCustomerView();
            return response;
        }


        public void CreateDeliveryAddress(CreateDeliveryAddressRequest request)
        {
            Customer customer = _customerRepository.FindBy(5);
            District district = _districtRepository.FindBy(request.DistrictId);
            PoliceStation policeStation = _policeStationRepository.FindBy(request.PoliceStationId);
            DeliveryAddress deliveryAddress = new DeliveryAddress();
            deliveryAddress.Address = request.Address;
            deliveryAddress.Customer = customer;
            deliveryAddress.CompanyName = request.CompanyName;
            deliveryAddress.District = district;
            deliveryAddress.PoliceStation = policeStation;
            deliveryAddress.OfficeOrHome = request.OfficeOrHome;
            deliveryAddress.ZipCode = request.ZipCode;
            deliveryAddress.MobileNo = request.MobileNo;
            customer.AddDeliveryAddress(deliveryAddress);
            _customerRepository.Save(customer);
            _uow.Commit();
        }


        public GetAllDistrictResponse GetAllDistricts()
        {
            GetAllDistrictResponse response = new GetAllDistrictResponse();
            IEnumerable<District> district = _districtRepository.FindAll();
            response.Districts = district.ConvertToDistrictViews();
            return response;
        }

        public GetAllPoliceStationResponse GetAllPoliceStations()
        {
            GetAllPoliceStationResponse response = new GetAllPoliceStationResponse();
            IEnumerable<PoliceStation> policeStation = _policeStationRepository.FindAll();
            response.PoliceStations = policeStation.ConvertToPoliceStationViews();
            return response;
        }
    }
}
