using Core.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandler
{
    public class ProvidersHandler
    {        
        public async Task<List<Providers>> GetProvidersByNationalId(ClsInput clsInput)
        {
            List<Providers> _providers = null;
            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44328/api/GetProvidersList"),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //Getting the input paramters as json 
            string content = GetJson(clsInput);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44328/api/GetProvidersList", httpContent);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonConvert.DeserializeObject<ProvidersResponse>(response.Content.ReadAsStringAsync().Result);
                _providers = res.responseData;
            }
            return _providers;

        }

        #region GetInputJson    
        public string GetJson(ClsInput clsInput)
        {
            string clientSecret = "{\r\n\"code\":\"CI\",\r\n\"nationalID\": \"" + clsInput.nationalID + "\",\r\n\"yearOfBirth\": \"" + clsInput.yearOfBirth + "\",\r\n\"insPolicyNo\": \"" + clsInput.insPolicyNo + "\"\r\n}\r\n";
            return clientSecret;
        }
        #endregion
    }
}
