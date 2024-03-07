using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repository.IRepository;

namespace Twkelat.Mobile.Repository
{
    public class LoginRepository : ILoginRepository
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public LoginRepository()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<AuthModelResponse> Login(string email, string password)
        {

            try
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {


                    var loginRequestModel = new TokenRequestModel { Email = email, Password = password };
                    var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");

                    var url = new Uri(string.Format(App.BaseURL + App.LoginController + App.LoginEndPoint, string.Empty));

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
