namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseServiceGrpc : Grpc.MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        // private readonly IMerchandiseService _merchandiseService;
        //
        // public MerchandiseServiceGrpc(IMerchandiseService merchandiseService)
        // {
        //     _merchandiseService = merchandiseService;
        // }
        //
        // public override async Task<AddMerchandiseResponse> AddMerchandise(AddMerchandiseRequest request,
        //     ServerCallContext context)
        // {
        //     var merchItem = await _merchandiseService.AddMerchandise(new MerchItemModelCreate
        //     {
        //         EmployeeId = request.EmployeeId
        //     }, context.CancellationToken);
        //
        //     return new AddMerchandiseResponse()
        //     {
        //         EmployeeId = merchItem.EmployeeId,
        //         MerchItemId = merchItem.MerchItemId,
        //         ResponsibleManagerId = merchItem.ResponsibleManagerId,
        //         StockItemId = merchItem.StockItemId
        //     };
        // }

        // public override async Task<GetMerchandiseIssuedEmployeeResponse> GetMerchandiseIssuedEmployee(GetMerchandiseIssuedEmployeeRequest request,
        //     ServerCallContext context)
        // {
        //     var merchItems = await _merchandiseService.GetMerchandiseIssuedEmployee(new MerchItemModelGet()
        //     {
        //         EmployeeId = request.EmployeeId
        //     }, context.CancellationToken);
        //     return new GetMerchandiseIssuedEmployeeResponse()
        //     {
        //         ListMerch =
        //         {
        //             merchItems.Select(x => new GetMerchandiseIssuedEmployeeResponseUnit
        //                 {
        //                     EmployeeId = x.EmployeeId,
        //                     MerchItemId = x.MerchItemId,
        //                     ResponsibleManagerId = x.ResponsibleManagerId,
        //                     StockItemId = x.StockItemId
        //                 }
        //             )
        //         }
        //     };
        // }
    }
}