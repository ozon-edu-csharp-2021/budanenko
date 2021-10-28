using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseServiceGrpcService : Grpc.MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseServiceGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        
        public override async Task<MerchItemPostResponse> AddMerchandiseRequest(MerchItemPostRequest request, ServerCallContext context)
        {
            var addResponse = await _merchandiseService.AddMerchandiseRequest(new MerchItemModelCreate
            {
                EmployeeId = request.EmployeeId
            }, context.CancellationToken);
            return await base.AddMerchandiseRequest(request, context);
        }

        public override async Task<MerchItemGetResponse> GetMerchandiseIssuedEmployee(MerchItemGetRequest request, ServerCallContext context)
        {
            var getResponse = await _merchandiseService.GetMerchandiseIssuedEmployee(new MerchItemModelGet()
            {
                EmployeeId = request.EmployeeId
            }, context.CancellationToken);
            return await base.GetMerchandiseIssuedEmployee(request, context);
        }
    }
}