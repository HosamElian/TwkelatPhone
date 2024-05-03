using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Services
{
    public class UserService : BaseService, IUserService
    {
        private string baseUrl;
        public UserService()
        {
            baseUrl = SD.SD.BaseURL;
        }

		public Task<T> CheckCode<T>(CheckRequestDTO dto)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.SD.ApiType.POST,
				Data = dto,
				Url = baseUrl + "Auth/checkCode",
			});
		}
		public Task<T> ChangeCode<T>(ChangeCodeRequestDTO dto)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.SD.ApiType.POST,
				Data = dto,
				Url = baseUrl + "Auth/changeCode",
			});
		}

		public Task<T> Login<T>(LoginRequestModel dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.SD.ApiType.POST,
                Data = dto,
                Url = baseUrl + "Auth/login",
            });
        }

        public Task<T> Register<T>(RegisterRequestModel dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.SD.ApiType.POST,
                Data = dto,
                Url = baseUrl + "Auth/register",
            });

        }
    }
}
