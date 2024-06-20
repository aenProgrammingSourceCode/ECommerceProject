using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Customers;
using alamapp.Model.RepositoryInterface.Customers;
using alamapp.Repositories.NH.SessionStorage;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Customers
{
   public class CustomerRepository:Repository<Customer,int>,ICustomerRepository
    {
       public CustomerRepository(IUnitOfWork uow):base(uow)
       {

       }
       public Customer FindBy(string userIdentityToken)
       {
           ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                    .CreateCriteria(typeof(Customer))
                    .Add(Expression.Eq(PropertyNameHelper
                    .ResolvePropertyName<Customer>
                   (c => c.IdentityToken), userIdentityToken));

           IList<Customer> customers = criteriaQuery.List<Customer>();

           Customer customer = customers.FirstOrDefault();
           return customer;
       }
    }
}
