using alamapp.Infrastructure.Domain;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.RepositoryInterface.Products
{
   public interface IProductRepository:IRepository<Product,int>
   {
       Product FindBy(string searchCriteria);
    }
}
