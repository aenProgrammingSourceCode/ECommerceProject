using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Categories;
using alamapp.Model.RepositoryInterface;
using alamapp.Model.RepositoryInterface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Products
{
   public class CategoryRepository:Repository<Category,int>, ICategoryRepository
    {
       public CategoryRepository(IUnitOfWork uow):base(uow)
       {
            
       }
    }
}
