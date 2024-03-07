using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Mobile.Models
{
    public class AuthModelResponse
    {
        public bool IsAuthenticated { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string ExpiresOn { get; set; }
        public string Image { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
