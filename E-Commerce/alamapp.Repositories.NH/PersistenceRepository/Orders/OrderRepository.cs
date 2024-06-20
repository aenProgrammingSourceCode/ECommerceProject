using alamapp.Infrastructure.Querying;
using alamapp.Infrastructure.UnitOfWorks;
using alamapp.Model.Orders;
using alamapp.Model.RepositoryInterface.Orders;
using alamapp.Repositories.NH.SessionStorage;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.PersistenceRepository.Orders
{
    public class OrderRepository : Repository<alamapp.Model.Orders.Order, int>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork uow)
            : base(uow)
        {

        }

        public alamapp.Model.Orders.Order FindBy(string IdentityToken)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                     .CreateCriteria(typeof(alamapp.Model.Orders.Order))
                     .Add(Expression.Eq(PropertyNameHelper
                     .ResolvePropertyName<alamapp.Model.Orders.Order>
                    (d => d.IdentityToken), IdentityToken));

            IList<alamapp.Model.Orders.Order> orders = criteriaQuery.List<alamapp.Model.Orders.Order>();

            alamapp.Model.Orders.Order order = orders.FirstOrDefault();
            return order;
        }
    }
}
