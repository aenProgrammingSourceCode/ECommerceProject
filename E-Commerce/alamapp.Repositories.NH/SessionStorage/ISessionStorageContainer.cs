using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.SessionStorage
{
   public interface ISessionStorageContainer
    {
       ISession GetCurrentSession();
       void Store(ISession session);
    }
}
