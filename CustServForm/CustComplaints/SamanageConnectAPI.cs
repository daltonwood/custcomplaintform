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

namespace CustServForm.CustComplaints
{
    public class SamanageConnectAPI
    {
        public static void PostToSamanage()
        {
            var requestUri = "https://api.samanage.com/incidents";
            string accessToken = "amxlZUBwbmYuY29t:eyJhbGciOiJIUzUxMiJ9.eyJ1c2VyX2lkIjoyNTMxMjU0LCJnZW5lcmF0ZWRfYXQiOiIyMDE5LTAyLTIyIDE1OjQzOjM0In0.jyRTSzj5OoyT9BkMK4L2SpgUUqxwz-_91gXmbeuxfHuw4mt4MhdIatrdLYnpKnIiQyY_oszjREHmuQww71zWEQ";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + accessToken);

            string json = String.Empty;
            //var path = HttpContext.Server.MapPath(@"~/CustComplaints/IncidentForm.json");
            using (StreamReader r = new StreamReader(@"C:\Users\dcook\source\repos\dcook63\custcomplaintform\CustServForm\CustComplaints\IncidentForm.json"))
            {
                json = r.ReadToEnd();
            }

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(requestUri, content).GetAwaiter().GetResult();
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var jobject = JObject.Parse(result);
                    throw new Exception(jobject.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}