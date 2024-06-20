using alamapp.Infrastructure.Domain;
using alamapp.Model.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Baskets
{
   public interface IBasketRepository:IRepository<Basket,Guid>
    {

    }
}
