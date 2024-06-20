using alamapp.Infrastructure.Domain;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Baskets
{
   public class Basket:EntityBase<Guid>,IAggregateRoot
    {
       private IList<BasketItem> _basketItems;
               
       private DateTime _createdDate;
       public Basket()
       {
           _basketItems = new List<BasketItem>();
           _createdDate = DateTime.Now;
       }

       
       public int NumberOfItem
       {
           get { return _basketItems.Sum(i => i.Qty); }
       }

       public decimal BasketTotal
       {
           get { return _basketItems.Sum(i => i.Qty * i.Product.Price); }
       }

       public void AddProductToBasket(Product product)
       {
           if (BasketContainAnItemFor(product))
               GetItemFor(product).IncreaseQty(1);
           else
           _basketItems.Add(BasketItemFactoryForProduct.CreateBasketItemForProduct(product, this));
       }
       public void AddPackageToBasket(Product product, int qty)
       {
           if (BasketContainAnItemFor(product))
               GetItemFor(product).IncreaseQty(qty);
           else
           _basketItems.Add(BasketItemFactory.CreateBasketItemFor(product, this, qty));
       }
       
       public void ChangeBasketItems(Product product, int qty)
       {
           if (BasketContainAnItemFor(product))
           { 
               GetItemFor(product).ChangeItemQty(qty);
           }
       }
       
       public void RemoveBasketItems(Product product)
       {
           if (BasketContainAnItemFor(product))
           {
               _basketItems.Remove(GetItemFor(product));
           }
       }
       public BasketItem GetItemFor(Product product)
       {
           return _basketItems.Where(i => i.Contains(product)).FirstOrDefault();
       }

       public bool BasketContainAnItemFor(Product product)
       {
           return _basketItems.Any(i => i.Contains(product));
       }
     
       public DateTime CreatedDate
       {
            get { return _createdDate; }
            set { _createdDate = value; }
       }
       public IEnumerable<BasketItem> BasketItems
       {
            get { return _basketItems; }
       }


       protected override void Validate()
       {
           throw new NotImplementedException();
       }
    }
}
