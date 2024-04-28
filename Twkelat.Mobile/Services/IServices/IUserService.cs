using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Mobile.Models.Request;

namespace Twkelat.Mobile.Services.IServices
{
    public interface IUserService
    {
        Task<T> Login<T>(LoginRequestModel dto);
        Task<T> Register<T>(RegisterRequestModel dto);
    }
}
