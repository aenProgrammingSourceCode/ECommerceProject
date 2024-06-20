using alamapp.Model.Baskets;
using alamapp.Model.Orders;
using alamapp.ServiceImplementations.Messaging.Orders;
using alamapp.ServiceImplementations.ViewModel.Orders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class OrderMapping
    {

       public static OrderView ConvertToOrderView(this Order order)
       {
           return Mapper.Map<Order, OrderView>(order);
       }

       public static IEnumerable<OrderView> ConvertToOrderViews(this IEnumerable<Order> order)
       {
           return Mapper.Map<IEnumerable<Order>, IEnumerable<OrderView>>(order);
       }

       public static Order ConvertToOrder(this Basket basket, CreateOrderRequest request)
       {
           Order order=new Order();
           order.IdentityToken = request.IdentityToken;
           order.UserName = request.UserName;
           foreach (BasketItem item in basket.BasketItems)
	        {
                order.AddItem(item.Product, item.Qty,request.IdentityToken);
	        }
           return order;
       }
       public static OrderItemView ConvertToOrderItemView(this OrderItem orderItem)
       {
           return Mapper.Map<OrderItem, OrderItemView>(orderItem);
       }


       public static PaymentView ConvertToPaymentView(this Payment payment)
       {
           return Mapper.Map<Payment, PaymentView>(payment);
       }

       public static IEnumerable<PaymentView> ConvertToPaymentViews(this IEnumerable<Payment> payments)
       {
           return Mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentView>>(payments);
       }
    }
}
