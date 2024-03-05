using GymBro.Application.Common.Interfaces;
using GymBro.Domain.Common;
using GymBro.Domain.Entities;
using GymBro.Domain.Interfaces;
using GymBro.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.Persistence.Interceptors
{
    internal sealed class InsertOutboxMessageInterceptor : SaveChangesInterceptor
    {



        private static readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All,
        };
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                InsertOutboxMessage(eventData.Context);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        
        


        private static void InsertOutboxMessage(DbContext context)
        {
            var createdDateUtc = DateTime.UtcNow;
            var outboxMessages = context
                .ChangeTracker
                .Entries<BaseAuditableEntity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.DomainEvents;
                    entity.ClearDomainEvents();
                    return domainEvents;
                })
                .Select(domainEvnet => new OutboxMessage(
                    Guid.NewGuid(),
                    domainEvnet.GetType().Name,
                    JsonConvert.SerializeObject(domainEvnet, _jsonSerializerSettings),
                    createdDateUtc
                    ))
                .ToList();
            context.Set<OutboxMessage>().AddRange(outboxMessages);
        }


       

    }
}
