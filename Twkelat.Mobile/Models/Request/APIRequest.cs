using static Twkelat.Mobile.SD.SD;

namespace Twkelat.Mobile.Models.Request
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
