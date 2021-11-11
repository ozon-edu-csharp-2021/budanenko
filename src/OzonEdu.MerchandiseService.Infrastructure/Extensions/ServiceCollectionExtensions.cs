using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.Services.MailService;
using OzonEdu.MerchandiseService.Domain.Services.StockApi;
using OzonEdu.MerchandiseService.Infrastructure.Handlers.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate;

namespace Microsoft.Extensions.DependencyInjection
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
            services.AddMediatR(typeof(AddMerchPackRequestCommandHandler).Assembly);
            services.AddMediatR(typeof(GetMerchPackIssuedEmployeeQueryHandler).Assembly);
            services.AddMediatR(typeof(AssembleMerchItemsCommandHandler).Assembly);
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMerchPackRepository, MerchPackRepository>();
            services.AddScoped<IMerchPackRequestRepository, MerchPackRequestRepository>();
            services.AddScoped<IMailServiceFacade, MailServiceFacade>();
            services.AddScoped<IStockApiFacade, StockApiFacade>();
            
            return services;
        }
        
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных репозиториев
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            
            
            return services;
        }
    }
}