using Core.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandler
{
    public class CustomerHandler
    {
        public List<Registration> GetUsers()
        {
            return GetAllUsers().Result;
        }
        public async Task<List<Registration>> GetAllUsers()
        {
            List<Registration> users = null;
            try
            {

                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/GetAllUsers";
                string cpath = url;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");


                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var a = JsonConvert.DeserializeObject<List<Registration>>(response.Content.ReadAsStringAsync().Result);
                    users = a;
                }
                else
                {
                    users = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }
        public Registration GetCustomerById(string Nid)
        {
            var _allcustomers = GetAllUsers();
            if (_allcustomers != null)
            {
                return _allcustomers.Result.Find(c => c.Iqama_NationalID == Nid);
            }
            else
            {
                return null;
            }
        }
    }
}
