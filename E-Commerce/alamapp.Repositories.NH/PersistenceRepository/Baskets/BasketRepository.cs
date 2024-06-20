using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Baskets;
using alamapp.Model.RepositoryInterface.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Baskets
{
   public class BasketRepository:Repository<Basket,Guid>, IBasketRepository
    {
       public BasketRepository(IUnitOfWork uow):base(uow)
       {

       }
    }
}
