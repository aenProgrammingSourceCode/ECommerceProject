using System.Collections.Generic;

namespace alamapp.ServiceImplementations.Messaging.Baskets
{
   public class CreateProductPackageRequest
    {
       public CreateProductPackageRequest()
       {
           productToAdd = new List<int>();
       }
        public int ProductId { get; set; }
        public IList<int> productToAdd { get; set; }
    }
}
