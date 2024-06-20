using alamapp.Infrastructure.Domain;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Orders
{
   public class Order:EntityBase<int>, IAggregateRoot
    {
        private string _userName;
        private IList<OrderItem> _orderItems;
        private DateTime _orderDate;
        private Payment _payment;
        private string _identityToken;
        public Order()
        {
            _orderItems = new List<OrderItem>();
            _orderDate = DateTime.Now;
            
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string IdentityToken
        {
            get { return _identityToken; }
            set { _identityToken = value; }
        }
        
        public Payment Payment
        {
            get { return _payment; }
        }
        public IEnumerable<OrderItem> OrderItems
        {
            get { return _orderItems; }
        }
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public void AddItem(Product product,int qty,string identityToken)
        {
            _orderItems.Add(OrderItemFactory.CreateOrderItemFactory(this, product, qty,identityToken));
        }

        public bool CheckForOrderItem(Product product)
        {
            return _orderItems.Any(o => o.Contains(product));
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
