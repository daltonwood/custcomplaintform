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

namespace CustServForm.CustComplaints
{
    public class SamanageConnectAPI
    {
        public static string PostToSamanage(dynamic postBody)
        {
            string accessToken = "amxlZUBwbmYuY29t:eyJhbGciOiJIUzUxMiJ9.eyJ1c2VyX2lkIjoyNTMxMjU0LCJnZW5lcmF0ZWRfYXQiOiIyMDE5LTAyLTIyIDE1OjQzOjM0In0.jyRTSzj5OoyT9BkMK4L2SpgUUqxwz-_91gXmbeuxfHuw4mt4MhdIatrdLYnpKnIiQyY_oszjREHmuQww71zWEQ";
            var requestUri = "https://api.samanage.com/incidents.xml";
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.samanage.v2.1+xml"));
            client.DefaultRequestHeaders.Add("X-Samanage-Authorization", "Bearer " + accessToken);
            var body = postBody;
            MessageBox.Show((JsonConvert.SerializeObject(body)));
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = client.PostAsync(requestUri, content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            return null;
        }
    }
}