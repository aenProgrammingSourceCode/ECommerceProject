using alamapp.Infrastructure.Domain;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Baskets
{
   public class BasketItem:EntityBase<int>,IAggregateRoot
    {
       private Product _product;
       private int _qty;
       private Basket _basket;
       
       public BasketItem()
       {

       }
       public BasketItem(Product product,Basket basket,int qty)
        {
            _product = product;
            _qty = qty;
            _basket = basket;
        }
 
       public decimal LineTotal
       {
           get { return Product.Price * Qty; }
       }
       public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public Basket Basket
        {
            get { return _basket; }
           
        }
        public void ChangeItemQty(int qty)
        {
            _qty = qty;
        }
        public void IncreaseQty(int qty)
        {
            _qty += qty;
        }
        public bool Contains(Product product)
        {
            return Product == product;
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
