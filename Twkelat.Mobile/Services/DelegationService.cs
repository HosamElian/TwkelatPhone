using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Services
{
    public class DelegationService : BaseService, IDelegationService
    {
        private string delegationUrl;
        public DelegationService()
        {
            delegationUrl = SD.SD.BaseURL;
        }
        public Task<T> CreateAsync<T>(T dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.SD.ApiType.POST,
                Data = dto,
                Url = delegationUrl + "Twkelat/AddNewBlcok"
            });
        }

        public Task<T> GetAllAsync<T>(string civilId)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.SD.ApiType.GET,
                Url = delegationUrl + $"Twkelat/GetAll?civilId={civilId}"
            });
        }

        public Task<T> UpdateAsync<T>(T dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.SD.ApiType.PUT,
                Data = dto,
                Url = delegationUrl + "Twkelat/ChangeStatus"
            });
        }

        public Task<T> GetbyIdAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.SD.ApiType.GET,
                Url = delegationUrl + $"Twkelat/GetById?blockId={id}"

            });
        }
    }
}
