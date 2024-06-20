using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Event
{
   public static class DomainEvents
    {
       public static IDomainEventHandlerFactory DomainEventHandlerFactory { get; set; }
       public static void Raise<T>(T domainEvent) where T:IDomainEvent
       {
           DomainEventHandlerFactory.GetDomainEventHandlerFor(domainEvent)
               .ForEach(h => h.Handle(domainEvent));
       }
    }
}
