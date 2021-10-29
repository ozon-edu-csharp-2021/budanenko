using System;
using Grpc.Core;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

try
{
    var response =
        await client.GetMerchandiseIssuedEmployeeAsync(new GetMerchandiseIssuedEmployeeRequest {EmployeeId = 28});
    foreach (var merchItem in response.ListMerch)
    {
        Console.WriteLine(
            $"EmployeeId: {merchItem.EmployeeId}, " +
            $"MerchItemId: {merchItem.MerchItemId}, " +
            $"ResponsibleManagerId: {merchItem.ResponsibleManagerId}, " +
            $"StockItemId: {merchItem.StockItemId}");
    }
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

try
{
    var merchItem = await client.AddMerchandiseAsync(new AddMerchandiseRequest() {EmployeeId = 28});
    Console.WriteLine(
        $"EmployeeId: {merchItem.EmployeeId}, " +
        $"MerchItemId: {merchItem.MerchItemId}, " +
        $"ResponsibleManagerId: {merchItem.ResponsibleManagerId}, " +
        $"StockItemId: {merchItem.StockItemId}");
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

try
{
    var response =
        await client.GetMerchandiseIssuedEmployeeAsync(new GetMerchandiseIssuedEmployeeRequest {EmployeeId = 28});
    foreach (var merchItem in response.ListMerch)
    {
        Console.WriteLine(
            $"EmployeeId: {merchItem.EmployeeId}, " +
            $"MerchItemId: {merchItem.MerchItemId}, " +
            $"ResponsibleManagerId: {merchItem.ResponsibleManagerId}, " +
            $"StockItemId: {merchItem.StockItemId}");
    }
}
catch (RpcException e)
{
    Console.WriteLine(e);
}