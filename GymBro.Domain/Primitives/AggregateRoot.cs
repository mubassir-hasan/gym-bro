using GymBro.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Primitives
{
    public abstract class AggregateRoot:BaseAuditableEntity
    {
        

        protected void RiseDomainEvent(IDomainEvent domainEvent)
        {
            AddDomainEvent(domainEvent);
        }
    }
}
