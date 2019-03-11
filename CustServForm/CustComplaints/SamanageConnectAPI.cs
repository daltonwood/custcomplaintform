using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web.UI;

namespace CustServForm.CustComplaints
{
    public class SamanageConnectAPI
    {
        public static bool status = false;
        public static bool PostToSamanage(JObject postBody)
        {
            string accessToken = "amxlZUBwbmYuY29t:eyJhbGciOiJIUzUxMiJ9.eyJ1c2VyX2lkIjoyNTMxMjU0LCJnZW5lcmF0ZWRfYXQiOiIyMDE5LTAyLTIyIDE1OjQzOjM0In0.jyRTSzj5OoyT9BkMK4L2SpgUUqxwz-_91gXmbeuxfHuw4mt4MhdIatrdLYnpKnIiQyY_oszjREHmuQww71zWEQ";
            var requestUri = "https://api.samanage.com/incidents.xml";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.samanage.v2.1+xml"));
            client.DefaultRequestHeaders.Add("X-Samanage-Authorization", "Bearer " + accessToken);
            //var body = postBody;
            StringContent content = new StringContent(postBody.ToString(), Encoding.UTF8, "application/json");
            var response = client.PostAsync(requestUri, content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return true;
            }
            else
                return false;
        }
    }
}