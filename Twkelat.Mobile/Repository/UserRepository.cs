using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repository.IRepository;
using Constants = Twkelat.Mobile.SD.Constants;
namespace Twkelat.Mobile.Repository
{
    public class UserRepository : IUserRepository
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public UserRepository()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<AuthModelResponse> Login(LoginModel loginModel)
        {

            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {


                    var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

                    var url = new Uri(string.Format(Constants.BaseURL + Constants.LoginController + Constants.LoginEndPoint, string.Empty));

                    HttpResponseMessage response = await _client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var userData = await response.Content.ReadFromJsonAsync<AuthModelResponse>();
                        if (userData != null)
                        {
                            return await Task.FromResult(userData);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }


        }

        public async Task<AuthModelResponse> Register(RegisterModel registerModel)
        {
            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {


                    var content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");

                    var url = new Uri(string.Format(Constants.BaseURL + Constants.LoginController + Constants.RegsterEndPoint, string.Empty));

                    HttpResponseMessage response = await _client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var userData = await response.Content.ReadFromJsonAsync<AuthModelResponse>();
                        if (userData != null)
                        {
                            return await Task.FromResult(userData);
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
