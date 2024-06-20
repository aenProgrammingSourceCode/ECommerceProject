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
   public class BasketItemRepository:Repository<BasketItem,int>, IBasketItemRepository
    {
       public BasketItemRepository(IUnitOfWork uow):base(uow)
       {

       }
    }
}
