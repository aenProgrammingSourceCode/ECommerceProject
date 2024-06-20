using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Baskets
{
   public class BasketItemFactory
    {
       public static BasketItem CreateBasketItemFor(Product product,Basket basket,int qty)
       {
           return new BasketItem(product, basket, qty);
       }
    }
}
