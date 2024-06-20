using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Orders;
using alamapp.Model.RepositoryInterface.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Orders
{
   public class PaymentRepository:Repository<Payment,int>,IPaymentRepository
    {
       public PaymentRepository(IUnitOfWork uow):base(uow)
       {

       }
    }
}
