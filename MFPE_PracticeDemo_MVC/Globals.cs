using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MFPE_PracticeDemo_MVC
{
    public static class Globals
    {
        public static HttpClient WebApiClient = new HttpClient();

        static Globals(){
            WebApiClient.BaseAddress = new Uri("https://localhost:44398/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}