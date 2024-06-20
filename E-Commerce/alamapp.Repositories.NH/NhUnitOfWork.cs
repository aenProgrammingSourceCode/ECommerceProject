using alamapp.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alamapp.Repositories.NH.SessionStorage;
using NHibernate;

namespace alamapp.Repositories.NH
{
   public class NhUnitOfWork:IUnitOfWork
    {
        public void RegisterAmanded(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitofworkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void RegisterNew(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitofworkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void RegisterRemoved(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitofworkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

       public void Commit()
       {
           using (ITransaction transaction=SessionFactory.GetCurrentSession().BeginTransaction())
           {
               try
               {
                   transaction.Commit();
               }
               catch (Exception ex)
               {
                   transaction.Rollback();
                   throw;
               }
           }
       }
            
    }
}
