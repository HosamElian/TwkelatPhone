using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Mobile.Services.IServices
{
    public interface IDelegationService
    {
        Task<T> GetAllAsync<T>(string civilId);
        Task<T> GetbyIdAsync<T>(int blockId);
        Task<T> CreateAsync<T>(T dto);
        Task<T> UpdateAsync<T>(T dto);
        //Task<T> DeleteAsync<T>(string id);
    }
}
