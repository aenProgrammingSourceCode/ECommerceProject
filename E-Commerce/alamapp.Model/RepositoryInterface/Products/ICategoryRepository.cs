using alamapp.Infrastructure.Domain;
using alamapp.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Products
{
   public interface ICategoryRepository:IRepository<Category,int>
    {
    }
}
