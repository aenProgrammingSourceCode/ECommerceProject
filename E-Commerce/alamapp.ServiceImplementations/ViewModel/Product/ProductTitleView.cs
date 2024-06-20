using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.ViewModel.Product
{
   public class ProductTitleView
   {
       public ProductTitleView()
       {
           ProductImageViews = new List<ProductImageView>();
           Products = new List<ProductView>();
       }
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public string CreatedDate { get; set; }
       public string CategoryName { get; set; }
       public string ColorName { get; set; }
       public int ColorId { get; set; }
       public int BrandId { get; set; }
       public string BrandName { get; set; }
       public string ManufactureName { get; set; }
       public string ProductModelName { get; set; }
       public int TotalProductByColor { get; set; }
       public decimal Price { get; set; }
       public Guid ImageId { get; set; }
       public IEnumerable<ProductView> Products { get; set; }
       public IEnumerable<ProductImageView> ProductImageViews { get; set; }
    }
}
