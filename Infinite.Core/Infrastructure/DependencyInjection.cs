using AutoMapper.EquivalencyExpression;
using FluentValidation;
using Infinite.Core.Business.Services.Base;
using Infinite.Core.Context;
using Infinite.Core.Infrastructure.Middleware;
using Infinite.Core.Infrastructure.Pipelines;
using Infinite.Core.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfiniteDbContext(this IServiceCollection services, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            services.AddDbContext<InfiniteContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();
            });

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            foreach (var implementationType in typeof(InfiniteContext)
            .Assembly
            .ExportedTypes
            .Where(t => t.IsClass && !t.IsAbstract))
            {
                foreach (var serviceType in implementationType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
                {
                    services.Add(new ServiceDescriptor(serviceType, implementationType, ServiceLifetime.Scoped));
                }
            }

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            return services;
        }

        public static void AddErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

    }
}
