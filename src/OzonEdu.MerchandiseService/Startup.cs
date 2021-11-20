using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AssembleMerchItems;
using OzonEdu.MerchandiseService.Infrastructure.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.Interceptors;
using OzonEdu.MerchandiseService.Services;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMerchandiseService, Services.MerchandiseService>();
            AddDatabaseComponents(services);
            services.AddInfrastructureServices();
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            services.AddHostedService<AssembleMerchItemsBackgroundService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchandiseServiceGrpc>();
                endpoints.MapControllers();
            });
        }

        private void AddDatabaseComponents(IServiceCollection services)
        {
            services.Configure<DatabaseConnectionOptions>(Configuration.GetSection(nameof(DatabaseConnectionOptions)));
        }

        public class AssembleMerchItemsBackgroundService : BackgroundService
        {
            private Timer _timer = null!;
            private readonly IMediator _mediator;
            private readonly IServiceProvider _serviceProvider;

            public AssembleMerchItemsBackgroundService(
                IMediator mediator,
                IServiceProvider serviceProvider)
            {
                _mediator = mediator;
                _serviceProvider = serviceProvider;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                async void AssembleMerchItemsJob(object state)
                {
                    using var scope = _serviceProvider.CreateScope();
                    var merchPackRequestRepository =
                        scope.ServiceProvider.GetRequiredService<IMerchPackRequestRepository>();
                    try
                    {
                        var merchPackRequests =
                            await merchPackRequestRepository.GetMerchPackRequestForAssembly(stoppingToken);

                        foreach (var merchPackRequest in merchPackRequests.Select(merchPackRequest =>
                            new AssembleMerchItemsCommand()
                            {
                                RequestNumber = merchPackRequest.RequestNumber!.Value
                            }))
                        {
                            var result = await _mediator.Send(merchPackRequest, stoppingToken);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                _timer = new Timer(AssembleMerchItemsJob, state: null, TimeSpan.FromSeconds(15),
                    TimeSpan.FromSeconds(45));
            }
        }
    }
}