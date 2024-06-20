using alamapp.Infrastructure.Querying;
using alamapp.Model.Products;
using alamapp.ServiceImplementations.Messaging.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Implementation
{
   public class ProductSearchGenerateQueryfromReuquest
    {
        public static Query CreateProductByIdQuery(GetProductRequest request)
         {
             Query productQuery = new Query();
             productQuery.Add(Criterion.Create<Product>(p => p.Id,request.Id, CriteriaOperator.Equal));
             return productQuery;
         }

        public static Query CreateProductByTitleIdQuery(int titleId)
        {
            Query productQuery = new Query();
            productQuery.Add(Criterion.Create<Product>(p => p.Title.Id, titleId, CriteriaOperator.Equal));
            return productQuery;
        }
         
    }
}
