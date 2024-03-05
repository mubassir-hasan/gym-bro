using GymBro.Infrastructure.BackgroundJobs.OutboxMessages;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Infrastructure.BackgroundJobs.Configuration
{
    public static class QuartzConfiguration
    {
        public static IServiceCollection AddQuartzConfig(this IServiceCollection services)
        {


            services
            .AddQuartz(q =>
            {
                var jobKey = new JobKey("OutboxMessages");
                q.AddJob<ProcessOutboxMessageJob>(opt=>opt.WithIdentity(jobKey));

                q.AddTrigger(opt => opt
                .ForJob(jobKey)
                .WithIdentity("OutboxMessagesTrigger")
                .WithSimpleSchedule(schedule=>schedule.WithIntervalInSeconds(15).RepeatForever())
                
                );
            })
            .AddQuartzHostedService(opt =>
            {
                opt.WaitForJobsToComplete = true;
            });
            //services.AddSingleton<ProcessOutboxMessageJob>();
            

            



            return services;
        }
    }
}
