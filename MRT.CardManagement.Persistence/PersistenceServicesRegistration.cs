using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services,
            IConfiguration configure)
        {
            services.AddDbContext<CardManagementDbContext>(options =>
                options.UseSqlServer(configure.GetConnectionString("CardManagementConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICardTypeRepository, CardTypeRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();

            return services;
        }
    }
}
