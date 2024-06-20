using alamapp.Infrastructure.Domain;
using alamapp.Model.Orders;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Orders
{
   public interface IOrderRepository:IRepository<Order,int>
    {
       Order FindBy(string IdentityToken);
    }
}
