using System.ComponentModel.DataAnnotations;

namespace Twkelat.Mobile.Models.Request
{
    public class LoginRequestModel
    {
        [Required]
        public string CivilId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
