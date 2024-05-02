using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Mobile.SD
{
    public static class SD
    {
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public static string SessionToken = "JWTToken";
        // icons
        public static string DocumentPage = "document_icon.svg";
        public static string HomePage = "home_icon.svg";
        public static string SettingPage = "setting_icon.svg";

        // url
        public static string BaseURL = "http://192.168.1.6:5204/api/";
    }
}
