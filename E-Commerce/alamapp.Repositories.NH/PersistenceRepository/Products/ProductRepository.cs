using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Products;
using alamapp.Model.RepositoryInterface.Products;
using alamapp.Repositories.NH.SessionStorage;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Products
{
  public  class ProductRepository:Repository<Product,int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow)
            : base(uow)
        {
           
        }
        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("Title", "ProductTitle");
            criteria.CreateAlias("ProductTitle.Category", "Category");
            criteria.CreateAlias("ProductTitle.Brand", "Brand");
            criteria.CreateAlias("ProductTitle.Manufacture", "Manufacture");
            criteria.CreateAlias("ProductTitle.ProductModel", "ProductModel");
            criteria.CreateAlias("ProductTitle.Color", "Color");
        }

        public Product FindBy(string searchCriteria)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                    .CreateCriteria(typeof(alamapp.Model.Products.Product))
                    .Add(Expression.Eq(PropertyNameHelper
                    .ResolvePropertyName<alamapp.Model.Products.Product>
                   (d => d.Name), searchCriteria));

            IList<alamapp.Model.Products.Product> products = criteriaQuery.List<alamapp.Model.Products.Product>();

            alamapp.Model.Products.Product product = products.FirstOrDefault();
            return product;
        }
    }
}

