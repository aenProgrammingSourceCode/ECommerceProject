using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Baskets
{
   public class BasketItemFactoryForProduct
    {
       public static BasketItem CreateBasketItemForProduct(Product product, Basket basket)
       {
           return new BasketItem(product, basket, 1);
       }
    }
}
