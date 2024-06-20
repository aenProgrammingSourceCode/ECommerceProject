using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Repositories.NH.SessionStorage
{
   public class SessionFactory
    {

       private static ISessionFactory _sessionFactory;

       public static void Initialized()
       {
           Configuration configurations = new Configuration();
           configurations.AddAssembly("alamapp.Repositories.NH");
           configurations.Configure();

           _sessionFactory = configurations.BuildSessionFactory();
       }

       private static ISessionFactory GetSessionFactory()
       {
           if (_sessionFactory == null)
               Initialized();
            
           return _sessionFactory;
       }

       private static ISession GetNewSession()
       {
           return GetSessionFactory().OpenSession();
       }

       public static ISession GetCurrentSession()
       {
           ISessionStorageContainer nhSessionStorageContainer = SessionStorageFactory.GetStorageContainer();
           ISession currentsession = nhSessionStorageContainer.GetCurrentSession();

           if (currentsession == null)
           { 
               currentsession = GetNewSession();
               nhSessionStorageContainer.Store(currentsession);
           }
           return currentsession;
       }

       
    }
}
