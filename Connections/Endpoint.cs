using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Server_App.Connections
{
    // under proparties EF_API
    // lounchSetting.jason
    //   "iisExpress": {
    //  "applicationUrl": "http://localhost:47737",
    //  "sslPort": 44371
    //    }
public static class Endpoint
    {
        public static string CoreUrl = "https://localhost:44371/";
        public static string AuthorEndpoint = $"{CoreUrl}api/author/";
        public static string LibraryEndpoint = $"{CoreUrl}api/book/";
        public static string RegisterEndpoint = $"{CoreUrl}api/personal/register";
        public static string LoginEndpoint = $"{CoreUrl}api/personal/login/";
    }
}
