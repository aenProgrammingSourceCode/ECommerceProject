using alamapp.Model.Baskets;
using alamapp.ServiceImplementations.ViewModel.Baskets;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class BasketItemMapping
   {
       public static IEnumerable<BasketItemView> ConvertToBasketItemViews(this IEnumerable<BasketItem> basketItems)
       {
           return Mapper.Map<IEnumerable<BasketItem>, IEnumerable<BasketItemView>>(basketItems);
       }
       public static BasketItemView ConvertToBasketItemView(this BasketItem baskets)
       {
           return Mapper.Map<BasketItem,BasketItemView>(baskets);
       }
    }
}
