using alamapp.Model.Baskets;
using alamapp.Model.Packages;
using alamapp.ServiceImplementations.Messaging.Baskets;
using alamapp.ServiceImplementations.ViewModel.Baskets;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class BasketMapping
    {

       public static Basket ConvertPackageToBasket(this Package package)
       {
           Basket basket = new Basket();

           foreach(PackageItem packageItem in package.PackageItems)
           {
               basket.AddPackageToBasket(packageItem.Product, packageItem.Quantity);
           }
           return basket;
       }


        public static BasketView ConvertToBasketView(this Basket basket)
        {
               return Mapper.Map<Basket, BasketView>(basket);
        }
    }

  
}
