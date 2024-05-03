using Newtonsoft.Json;
using System.Text;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Services
{
    public class BaseService : IBaseService
    {
        HttpClient _client;

        public BaseService()
        {
            this.responseModel = new();
        }
        public APIResponse responseModel { get; set; }
        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {

                var client = _client = new HttpClient();
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                message.Method = apiRequest.ApiType switch
                {
                    SD.SD.ApiType.POST => HttpMethod.Post,
                    SD.SD.ApiType.PUT => HttpMethod.Put,
                    SD.SD.ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };
                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIRespone = JsonConvert.DeserializeObject<T>(apiContent);
                return APIRespone;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false,
                };

                var res = JsonConvert.SerializeObject(dto);
                var ApiRespone = JsonConvert.DeserializeObject<T>(res);
                return ApiRespone;
            }

        }
    }
}
