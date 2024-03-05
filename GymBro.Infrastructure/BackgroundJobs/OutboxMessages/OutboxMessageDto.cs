using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.BackgroundJobs.OutboxMessages
{
    internal sealed record OutboxMessageDto(Guid Id, string Name, string Content);
    
}
