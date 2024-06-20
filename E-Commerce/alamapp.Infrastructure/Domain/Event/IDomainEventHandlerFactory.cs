using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Event
{
   public interface IDomainEventHandlerFactory
    {
       IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlerFor<T>(T DomainEvent)
           where T : IDomainEvent;
    }
}
