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
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AssembleMerchItems;
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

        public class AssembleMerchItemsBackgroundService : BackgroundService
        {
            private Timer _timer = null!;
            private readonly IMerchPackRequestRepository _merchPackRequestRepository;
            private readonly IMediator _mediator;

            public AssembleMerchItemsBackgroundService(
                IMerchPackRequestRepository merchPackRequestRepository,
                IMediator mediator)
            {
                _merchPackRequestRepository = merchPackRequestRepository;
                _mediator = mediator;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                async void AssembleMerchItemsJob(object state)
                {
                    try
                    {
                        var merchPackRequests =
                            await _merchPackRequestRepository.GetMerchPackRequestForAssembly(stoppingToken);

                        foreach (var addMerchPackRequestCommand in merchPackRequests.Select(merchPackRequest =>
                            new AssembleMerchItemsCommand()
                            {
                                RequestNumber = merchPackRequest.RequestNumber!.Value
                            }))
                        {
                            var result = await _mediator.Send(addMerchPackRequestCommand, stoppingToken);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                _timer = new Timer(AssembleMerchItemsJob, state: null, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(45));
            }
        }
    }
}