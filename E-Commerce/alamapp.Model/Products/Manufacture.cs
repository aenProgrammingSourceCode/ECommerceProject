using alamapp.Infrastructure.Domain;
using alamapp.Model.RepositoryInterface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Model.Products
{
    public class Manufacture : EntityBase<int>, IProductAttribute, IAggregateRoot
    {

        public string Name { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
