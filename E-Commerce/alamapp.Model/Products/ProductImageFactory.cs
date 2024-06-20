using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Products
{
   public static class ProductImageFactory
    {
       public static ProductImage CreateProductImageFor(ProductTitle productTitle)
       {
           return new ProductImage(productTitle);
       }
    }
}
