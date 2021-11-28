using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AssembleMerchItems;

namespace OzonEdu.MerchandiseService
{
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
                            MerchPackRequest = merchPackRequest
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