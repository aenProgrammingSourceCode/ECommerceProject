using alamapp.ServiceImplementations.Messaging.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Interface
{
    public interface IBasketService
    {
        CreateProductBasketResponse AddProductToBasket(CreateProductBasketRequest request);
        CreateBasketResponse AddPackageToBasket(CreateBasketRequest request);
        GetBasketResponse GetBasket(GetBasketRequest request);
        GetBasketItemResponse GetBasketItem(GetBasketItemRequest request);
        ModifyProductBasketResponse ModifyProductBasket(ModifyProductBasketRequest request);
        DeleteBasketResponse DeleteBasket(DeleteBasketRequest request);
        void DeleteBasketItemById(int id);
    }
}
