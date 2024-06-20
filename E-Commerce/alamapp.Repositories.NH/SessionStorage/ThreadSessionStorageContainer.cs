using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.SessionStorage
{
   public class ThreadSessionStorageContainer:ISessionStorageContainer
    {
       private static readonly Hashtable _nhsession = new Hashtable();
        public NHibernate.ISession GetCurrentSession()
        {
            ISession nhsession = null;
            if (_nhsession.Contains(GetThreadName()))
               nhsession = (ISession)_nhsession[GetThreadName()];
                return nhsession;
        }

        public void Store(NHibernate.ISession session)
        {
            if (_nhsession.Contains(GetThreadName()))
                _nhsession[GetThreadName()] = session;
            else
                _nhsession.Add(GetThreadName(), session);
        }

       public static string GetThreadName()
        {
           return Thread.CurrentThread.Name;
        }
    }
}
