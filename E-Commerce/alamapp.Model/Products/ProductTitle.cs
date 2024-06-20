using alamapp.Infrastructure.Domain;
using alamapp.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Products
{
   public class ProductTitle:EntityBase<int>,IAggregateRoot
    {
        private IList<ProductImage> _productImage;
        public ProductTitle()
        {
            _productImage = new List<ProductImage>();
           CreatedDate = DateTime.Now;
        }
        public void AddProductImage()
        {
            _productImage.Add(ProductImageFactory.CreateProductImageFor(this));
        }
        public IEnumerable<ProductImage> ProductImage
        {
           get { return _productImage; }
        }
        public string MadeIn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Color Color { get; set; }
        public string FabricName { get; set; }
        public SubCategory SubCategory { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Manufacture Manufacture { get; set; }
        public ProductModel ProductModel { get; set; }
        public Guid ImageId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal Price { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
