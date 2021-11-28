using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<List<MerchItemResponse>> V2GetMerchandiseIssuedEmployee(GetMerchPackIssuedEmployeeModel getMerchPackIssuedEmployeeModel, CancellationToken token);
        
        Task<List<MerchItemResponse>> V2AddMerchandiseRequest(AddMerchPackRequestPostViewModel postViewPostViewModel, CancellationToken token);
        
        Task<List<MerchItemResponse>> V3AddMerchPackRequest(AddMerchPackRequestPostViewModel postViewPostViewModel, CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MerchItemResponse>> V2GetMerchandiseIssuedEmployee(GetMerchPackIssuedEmployeeModel getMerchPackIssuedEmployeeModel, CancellationToken token)
        {
            using var response = await _httpClient.PostAsJsonAsync("v2/api/merchandise/get", getMerchPackIssuedEmployeeModel, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }

        public async Task<List<MerchItemResponse>> V2AddMerchandiseRequest(AddMerchPackRequestPostViewModel postViewPostViewModel, CancellationToken token)
        {
            using var response = await _httpClient.PostAsJsonAsync("v2/api/merchandise/add", postViewPostViewModel, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }
        
        public async Task<List<MerchItemResponse>> V3AddMerchPackRequest(AddMerchPackRequestPostViewModel postViewPostViewModel, CancellationToken token)
        {
            using var response = await _httpClient.PostAsJsonAsync("v3/api/merchandise/add", postViewPostViewModel, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }
    }
}