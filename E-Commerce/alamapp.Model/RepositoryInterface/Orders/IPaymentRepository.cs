using alamapp.Infrastructure.Domain;
using alamapp.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Orders
{
   public interface IPaymentRepository : IRepository<Payment, int>
    {
    }
}
