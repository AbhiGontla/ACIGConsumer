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
    public class TOBHandler
    {
        public async Task<TOB> GetTOBByNationalId(ClsInput clsInput)
        {
            TOB  tob= null;
            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44328/api/GetTOBs"),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //Getting the input paramters as json 
            string content = GetJson(clsInput);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44328/api/GetTOBs", httpContent);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonConvert.DeserializeObject<TOBResponse>(response.Content.ReadAsStringAsync().Result);
                tob = res.responseData;
            }
            return tob;

        }

        #region GetInputJson    
        public string GetJson(ClsInput clsInput)
        {
            string clientSecret = "{\r\n\"code\":\"CI\",\r\n\"nationalID\": \"" + clsInput.nationalID + "\",\r\n\"yearOfBirth\": \"" + clsInput.yearOfBirth + "\",\r\n\"insPolicyNo\": \"" + clsInput.insPolicyNo + "\"\r\n}\r\n";
            return clientSecret;
        }
        #endregion

        public TOB GetTOBById(string nationalId, string yob)
        {
            return GetTOBByNationalId(nationalId, yob).Result;
        }
        public async Task<TOB> GetTOBByNationalId(string nationalId, string yob)
        {
            var result = new TOB();
            if (nationalId != null && yob != null)
            {
                var clsInput = new ClsInput();
                clsInput.code = "CI";
                clsInput.nationalID = nationalId;
                DateTime date = Convert.ToDateTime(yob);
                clsInput.yearOfBirth = date.Year.ToString();
                clsInput.insPolicyNo = "";
                result = await GetTOBByNationalId(clsInput);
            }
            return result;
        }
    }
}
