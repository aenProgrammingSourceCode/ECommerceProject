using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Customers
{
   public class DeliveryAddress:EntityBase<int>,IAggregateRoot
    {
        private Customer _customer;
        private string _address,_mobileNo, _zipCode, _officeOrHome, _createdDate, _companyName;
        private District _district;

        public District District
        {
            get { return _district; }
            set { _district = value; }
        }
        private PoliceStation _policeStation;

        public PoliceStation PoliceStation
        {
            get { return _policeStation; }
            set { _policeStation = value; }
        }
        public DeliveryAddress()
        {
            CreatedDate = DateTime.Now.ToString();
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public string OfficeOrHome
        {
            get { return _officeOrHome; }
            set { _officeOrHome = value; }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
