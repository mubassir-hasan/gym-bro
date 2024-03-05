using Dapper;
using GymBro.Abstractions.Shared;
using GymBro.Application.Common.Interfaces;
using GymBro.Domain.Primitives;
using MediatR;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.BackgroundJobs.OutboxMessages
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxMessageJob : IJob
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IPublisher _publisher;

        public ProcessOutboxMessageJob(ISqlConnectionFactory context, IPublisher publisher)
        {
            _connectionFactory = context;
            _publisher = publisher;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using(var connection= _connectionFactory.GetOpenConnection())
            {
                string sql = @"SELECT 
                                Id,
                                Name,
                                Content
                                From OutboxMessages
                                Where ProcessedOnUtc IS NULL
                                ORDER BY CreatedOnUtc DESC
                            ";
                var messages = await connection.QueryAsync<OutboxMessageDto>(sql);
                foreach (var message in messages)
                {
                    Type? type = Assembly.GetAssembly(typeof(IDomainEvent))?.GetType(message.Name);
                    if(type is not null)
                    {
                        var notification = JsonConvert.DeserializeObject(message.Content, type);
                        if(notification is not null)
                        {
                            await _publisher.Publish(notification);
                            await UpdateOutboxTabel(connection, message.Id);
                        }
                    }
                }
            }
        }
        private static async Task UpdateOutboxTabel(IDbConnection connection,Guid id)
        {
            string sql = "UPDATE OutboxMessages SET ProcessedOnUtc=@date WHERE [Id]=@id";

            await connection.ExecuteAsync(sql, new
            {
                id = id,
                date = DateTime.UtcNow
            });
        }
    }
}
