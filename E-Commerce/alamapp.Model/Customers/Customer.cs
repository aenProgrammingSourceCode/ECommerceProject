using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Customers
{
   public class Customer:EntityBase<int>, IAggregateRoot
    {
        private string _userName, _mobileNo, _createdDate, _dateOfBirth, _country, _gender, _identityToken;
        private IList<DeliveryAddress> _deliveryAddress = new List<DeliveryAddress>();
        
        public Customer()
        {
           
            CreatedDate = DateTime.Now.ToString();
        }


        public void AddDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            _deliveryAddress.Add(deliveryAddress);
        }
        public IEnumerable<DeliveryAddress> DeliveryAddress
        {
            get { return _deliveryAddress; }
        }
        public string IdentityToken
        {
            get { return _identityToken; }
            set { _identityToken = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
       protected override void Validate()
       {
           throw new NotImplementedException();
       }
    }
}
