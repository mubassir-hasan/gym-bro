﻿using GymBro.Abstractions.Caching;
using GymBro.Abstractions.Shared;
using GymBro.Application.Common.Interfaces;
using GymBro.Domain.Entities;
using GymBro.Domain.Interfaces;
using GymBro.Infrastructure.BackgroundJobs.Configuration;
using GymBro.Infrastructure.Caches;
using GymBro.Infrastructure.Persistence;
using GymBro.Infrastructure.Persistence.Interceptors;
using GymBro.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymBro.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<InsertOutboxMessageInterceptor>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("GymBroDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>((sp, options) =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    .AddInterceptors(sp.GetRequiredService<InsertOutboxMessageInterceptor>())
                    .AddInterceptors(sp.GetRequiredService<AuditableEntitySaveChangesInterceptor>())
                    );
            }
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;

                // Also tried SameSiteMode.None
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;

                })
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IDateTime,DateTimeService>();

            //cache
            services.AddDistributedMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();

            services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

            return services;
        }
    }
}