using alamapp.Infrastructure.Domain;
using alamapp.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Packages
{
   public class Package:EntityBase<int>, IAggregateRoot
    {
        private IList<PackageItem> _packageItems;

        public IEnumerable<PackageItem> PackageItems
        {
            get { return _packageItems; }
        }
        public Package()
        {
           _packageItems = new List<PackageItem>();
        }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ImageId { get; set; }
        private Category _category;

        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
