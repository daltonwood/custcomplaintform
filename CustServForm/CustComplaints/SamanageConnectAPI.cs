using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace CustServForm.CustComplaints
{
    public class SamanageConnectAPI
    {
        public static void PostToSamanage()
        {
            var requestUri = "";
            string accessToken = string.Empty;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Build Post Body
            var postBody = new Dictionary<string, string>();
        }
    }
}