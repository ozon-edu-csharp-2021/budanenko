using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Services.MailService;
using OzonEdu.MerchandiseService.Domain.Services.StockApi;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AssembleMerchItems;
using OzonEdu.StockApi.Grpc;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate
{
    public class AssembleMerchItemsCommandHandler : IRequestHandler<AssembleMerchItemsCommand, Unit>
    {
        // private readonly IEmployeeRepository _employeeRepository;

        private readonly IMerchPackRequestRepository _merchPackRequestRepository;
        private readonly StockApiGrpc.StockApiGrpcClient _stockApiGrpcClient;
        // private readonly IMerchPackRepository _merchPackRepository;
        private readonly IStockApiFacade _stockApiFacade;
        private readonly IMailServiceFacade _mailServiceFacade;

        public AssembleMerchItemsCommandHandler(
            // IEmployeeRepository employeeRepository,
            IMerchPackRequestRepository merchPackRequestRepository,
            // IMerchPackRepository merchPackRepository,
            IStockApiFacade stockApiFacade,
            IMailServiceFacade mailServiceFacade, 
            StockApiGrpc.StockApiGrpcClient stockApiGrpcClient)
        {
            // _employeeRepository = employeeRepository;
            _merchPackRequestRepository = merchPackRequestRepository;
            // _merchPackRepository = merchPackRepository;
            _stockApiFacade = stockApiFacade;
            _mailServiceFacade = mailServiceFacade;
            _stockApiGrpcClient = stockApiGrpcClient;
        }

        public async Task<Unit> Handle(AssembleMerchItemsCommand request, CancellationToken cancellationToken)
        {
            // if (Equals(request.MerchPackRequest.RequestStatus, RequestStatus.New))
            // {
            //     _merchPackRequestRepository.CreateMerchItems(request.MerchPackRequest);
            // }
            var a = _stockApiGrpcClient.GetAllStockItems(new Empty(), null, null, cancellationToken);
            
            request.MerchPackRequest.ChangeStatus(RequestStatus.InWork);
            var resultUpdateRecord =
                await _merchPackRequestRepository.UpdateStatusAsync(request.MerchPackRequest, cancellationToken);

            // var merchPackRequest =
            //     await _merchPackRequestRepository.FindByRequestNumberAsync(new MerchPackRequestId(request.RequestNumber), cancellationToken);

            // var employee = await _employeeRepository.FindByIdAsync(merchPackRequest.EmployeeId, cancellationToken);

            // var merchPackType = await _merchPackRepository.GetAllMerchItemTypes(merchPackRequest.MerchPack, cancellationToken);

            // if (Equals(merchPackRequest.RequestStatus, RequestStatus.New))
            // {
            //     merchPackRequest.CreateMerchItemsStatus(merchPackType.MerchTypes.ToList());
            // }
            //
            // merchPackRequest.ChangeStatus(RequestStatus.InWork);
            //
            // var allStockItems = await _stockApiFacade.GetAll();
            //
            // foreach (var merchItemsStatus in merchPackRequest.MerchItemsStatus!.Where(x => x.Status != Status.Reserved))
            // {
            //     var stockItem = allStockItems.Single(x => x.ItemType == merchItemsStatus.MerchItemType.Id);
            //
            //     var itemAvailableQuantity = await _stockApiFacade.GetAvailableQuantity(stockItem.SkuId);
            //
            //     if (itemAvailableQuantity > 0)
            //     {
            //         var resultTryReserved = await _stockApiFacade.SetItemReserved(stockItem.SkuId);
            //         merchItemsStatus.Status = resultTryReserved ? Status.Reserved : Status.WaitingDelivery;
            //     }
            //     else
            //         merchItemsStatus.Status = Status.WaitingDelivery;
            // }
            //
            // if (merchPackRequest.MerchItemsStatus!.All(x => x.Status == Status.Reserved))
            // {
            //     await _mailServiceFacade.SendMail(employee.Email, "Приходите за мерчом!");
            //     employee.AddReceivedMerchType(merchPackRequest.MerchPack);
            //     merchPackRequest.ChangeStatus(RequestStatus.Done);
            // }
            // else
            // {
            //     merchPackRequest.ChangeStatus(RequestStatus.WaitingDelivery);
            // }
            //
            // await _merchPackRequestRepository.UpdateAsync(merchPackRequest, cancellationToken);
            // await _employeeRepository.UpdateAsync(employee, cancellationToken);
            // await _merchPackRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}