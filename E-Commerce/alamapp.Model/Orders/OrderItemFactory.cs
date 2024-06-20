using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public static class OrderItemFactory
    {
       public static OrderItem CreateOrderItemFactory(Order order,Product product,int qty,string identityToken)
       {
           return new OrderItem(order, product, qty, identityToken);
       }
    }
}
