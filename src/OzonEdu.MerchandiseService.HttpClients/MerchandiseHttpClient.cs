using System;
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
     //   Task<List<MerchItemResponse>> V2GetMerchandiseIssuedEmployee(CancellationToken token);
        
        Task<List<MerchItemResponse>> V2AddMerchandiseRequest(CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
/*
        public async Task<List<MerchItemResponse>> GetMerchandiseIssuedEmployee(CancellationToken token)
        {
            var getViewModel = new MerchItemGetViewModel {EmployeeId = 28};
            using var response = await _httpClient.GetAsync("v2/api/merchandise", getViewModel, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }
*/
        public async Task<List<MerchItemResponse>> V2AddMerchandiseRequest(CancellationToken token)
        {
            var getViewModel = new MerchItemPostViewModel {EmployeeId = 28};
            using var response = await _httpClient.PostAsJsonAsync("v2/api/merchandise", getViewModel, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }
    }
}