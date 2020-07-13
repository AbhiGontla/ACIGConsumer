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
    public class ClaimsHandler
    {



        #region ProviderClaims

        public async Task<List<PaidClaims>> GetPaidClaimsByNationalId(ClsInput clsInput)
        {
            List<PaidClaims> _paidClaims = null;
            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44328/api/GetPaidClaims"),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //Getting the input paramters as json 
            string content = GetJson(clsInput);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44328/api/GetPaidClaims", httpContent);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonConvert.DeserializeObject<PaidClaimsResponse>(response.Content.ReadAsStringAsync().Result);
                _paidClaims = res.responseData;
            }
            return _paidClaims;

        }

        #region GetInputJson    
        public string GetJson(ClsInput clsInput)
        {
            string clientSecret = "{\r\n\"code\":\"CI\",\r\n\"nationalID\": \"" + clsInput.nationalID + "\",\r\n\"yearOfBirth\": \"" + clsInput.yearOfBirth + "\",\r\n\"insPolicyNo\": \"" + clsInput.insPolicyNo + "\"\r\n}\r\n";
            return clientSecret;
        }
        #endregion

        public async Task<List<OSClaims>> GetOSClaimsByNationalId(ClsInput clsInput)
        {
            List<OSClaims> _oSClaims = null;
            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:44328/api/GetOSClaims"),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            //Getting the input paramters as json 
            string content = GetJson(clsInput);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44328/api/GetOSClaims", httpContent);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonConvert.DeserializeObject<OSClaimsResponse>(response.Content.ReadAsStringAsync().Result);
                _oSClaims = res.responseData;
            }
            return _oSClaims;

        }
        #endregion


        #region Reimbursment Claims        

                
        public async Task<List<ReImClaims>> GetReImClaimsByClientId(string id)
        {
            List<ReImClaims> reImClaims = null;
            try
            {
                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/GetClaimsByClientId/ClientId/";
                string cpath = url + id;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                HttpResponseMessage response = await httpClient.GetAsync(cpath);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var res = JsonConvert.DeserializeObject<List<ReImClaims>>(response.Content.ReadAsStringAsync().Result);
                    reImClaims = res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reImClaims;
        }


      
        public async Task<RequestCreateDTO> GetReImClaimDetailsById(string id)
        {
            RequestCreateDTO reImClaimdetails = null;
            try
            {

                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/GetClaimDetailsById/Id/";
                string cpath = url + id;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                HttpResponseMessage response = await httpClient.GetAsync(cpath);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var a = JsonConvert.DeserializeObject<RequestCreateDTO>(response.Content.ReadAsStringAsync().Result);
                    reImClaimdetails = a;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reImClaimdetails;
        }
        #endregion
    }
}
