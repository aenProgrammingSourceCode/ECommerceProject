using alamapp.Infrastructure.Domain;
using alamapp.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Packages
{
   public class PackageItem:EntityBase<int>
    {
        private Package _package;

        public Package Package
        {
            get { return _package; }
            set { _package = value; }
        }
        private Unit _unit;

        public Unit Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
       
        public int Quantity { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
