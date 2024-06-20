using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Domain
{
   public interface IRepository<T, TId>:IReadOnlyRepository<T, TId> where T:IAggregateRoot
    {
       void Add(T entity);
       void Save(T entity);
       void Delete(T entity);
    }
}
