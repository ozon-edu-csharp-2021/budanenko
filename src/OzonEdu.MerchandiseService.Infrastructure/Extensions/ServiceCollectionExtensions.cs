using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Domain.Services.MailService;
using OzonEdu.MerchandiseService.Domain.Services.StockApi;
using OzonEdu.MerchandiseService.Infrastructure.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using OzonEdu.StockApi.Grpc;
using OzonEdu.StockApi.Infrastructure.Configuration;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    /// <summary>
    /// Класс расширений для типа <see cref="IServiceCollection"/> для регистрации инфраструктурных сервисов
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных сервисов
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            services.AddHostedService<AssembleMerchItemsBackgroundService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            // services.AddScoped<IMerchPackRepository, MerchPackRepository>();
            services.AddScoped<IMerchPackRequestRepository, MerchPackRequestRepository>();
            services.AddScoped<IMailServiceFacade, MailServiceFacade>();
            services.AddScoped<IStockApiFacade, StockApiFacade>();
            // services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<IChangeTracker, ChangeTracker>();
            // services.AddScoped<IQueryExecutor, QueryExecutor>();
            
            return services;
        }
        
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<DatabaseConnectionOptions>(configuration.GetSection(nameof(DatabaseConnectionOptions)));
            
            services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChangeTracker, ChangeTracker>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();

            return services;
        }
        
        public static IServiceCollection AddStockApiGrpcServiceClient(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionAddress = configuration.GetSection(nameof(StockApiGrpcServiceConfiguration))
                .Get<StockApiGrpcServiceConfiguration>().ServerAddress;
            if(string.IsNullOrWhiteSpace(connectionAddress))
                connectionAddress = configuration
                    .Get<StockApiGrpcServiceConfiguration>()
                    .ServerAddress;

            services.AddScoped<StockApiGrpc.StockApiGrpcClient>(opt =>
            {
                var channel = GrpcChannel.ForAddress(connectionAddress);
                return new StockApiGrpc.StockApiGrpcClient(channel);
            });
            return services;
        }
    }
}