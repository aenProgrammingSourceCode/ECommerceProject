using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Products
{
   public class ProductImage:EntityBase<int>,IAggregateRoot
    {
       private ProductTitle _productTitle;
       private Guid _sampleImage;
       public Guid SampleImage
       {
           get { return _sampleImage; }
           set { _sampleImage = value; }
       }
       public ProductImage()
       {
         
       }
       public ProductImage(ProductTitle productTitle)
       {
           // TODO: Complete member initialization
           _productTitle = productTitle;
           Id =0;
       }

       public ProductTitle ProductTitle
       {
           get { return _productTitle; }
           set { _productTitle = value; }
       }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
