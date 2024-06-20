using alamapp.Infrastructure.Domain;
using alamapp.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Customers
{
   public interface ICustomerRepository:IRepository<Customer,int>
    {
       Customer FindBy(string userIdentityToken);
    }
}
