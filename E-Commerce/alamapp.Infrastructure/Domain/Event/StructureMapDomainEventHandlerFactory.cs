using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Event
{
   public class StructureMapDomainEventHandlerFactory:IDomainEventHandlerFactory
    {
        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlerFor<T>(T DomainEvent) where T : IDomainEvent
        {
            return ObjectFactory.GetAllInstances<IDomainEventHandler<T>>();
        }
    }
}
