using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using ACIGConsumer.Models;
using Microsoft.Extensions.Options;

namespace ACIGConsumer.Controllers
{
    [Route("api")]    
    public class ApiController : Controller
    {
        private readonly IOptions<ApplConfig> appSettings;
        public ApiController(IOptions<ApplConfig> _config)
        {
            appSettings = _config;
        }

        [Route("GetPaidClaims")]
        [HttpGet]
        public async Task<Response> GetpaidClaims(string param)
        {            
            string url = appSettings.Value.Urls.GetApprovals;
            string username = appSettings.Value.BasicAuth.Username;
            string pass = appSettings.Value.BasicAuth.Password;
            Response res = null;

            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(url),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //This is the key section you were missing    
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username+":"+pass);
            string val = System.Convert.ToBase64String(plainTextBytes);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
            //Getting the input paramters as json 
            string content = GetJson("2359237050", "2013", null);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                res = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                res.responseCode = response.StatusCode.ToString();
                return res;
            }
            return res;
        }

        #region GetInputJson    
        public string GetJson(string nationalId, string YOB, int? insPolicyno)
        {
            string clientSecret = "{\r\n\"code\":\"CI\",\r\n\"nationalID\": \"" + nationalId + "\",\r\n\"yearOfBirth\": \"" + YOB + "\",\r\n\"insPolicyNo\": \"" + insPolicyno + "\"\r\n}\r\n";
            return clientSecret;
        }
        #endregion
    }
}
