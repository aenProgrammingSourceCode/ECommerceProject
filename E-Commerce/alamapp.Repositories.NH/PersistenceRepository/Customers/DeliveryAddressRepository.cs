using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Customers;
using alamapp.Model.RepositoryInterface.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Customers
{
   public class DeliveryAddressRepository:Repository<DeliveryAddress,int>,IDeliveryAddressRepository
    {
       public DeliveryAddressRepository(IUnitOfWork uow)
           : base(uow)
       {

       }
    }
}
