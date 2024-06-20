using alamapp.Infrastructure.Domain;
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
   public class OrderItemRepository:Repository<OrderItem,int>,IOrderItemRepository
    {
        public OrderItemRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public OrderItem FindBy(string IdentityToken)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession()
                     .CreateCriteria(typeof(alamapp.Model.Orders.OrderItem))
                     .Add(Expression.Eq(PropertyNameHelper
                     .ResolvePropertyName<alamapp.Model.Orders.OrderItem>
                    (d => d.IdentityToken), IdentityToken));

            IList<alamapp.Model.Orders.OrderItem> orderItems = criteriaQuery.List<alamapp.Model.Orders.OrderItem>();

            alamapp.Model.Orders.OrderItem orderItem = orderItems.FirstOrDefault();
            return orderItem;
        }
    }
}
