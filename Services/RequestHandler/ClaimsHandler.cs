using Core.Api;
using Core.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandler
{
    public class ClaimsHandler
    {

        private CustomerHandler CustomerHandler;
        public ClaimsHandler(CustomerHandler customerHandler)
        {
            CustomerHandler = customerHandler;
        }

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
                string url = "https://localhost:44328/api/GetClaimsByClientId_New/ClientId/";
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
                string url = "https://localhost:44328/api/GetClaimDetailsById_New/Id/";
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


        public async Task<List<MRClaimType>> GetClaimsTypes()
        {
            List<MRClaimType> mRClaimTypes = null;
            try
            {

                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/GetClaimsTypes";
                string cpath = url;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                HttpResponseMessage response = await httpClient.GetAsync(cpath);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var a = JsonConvert.DeserializeObject<List<MRClaimType>>(response.Content.ReadAsStringAsync().Result);
                    mRClaimTypes = a;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mRClaimTypes;
        }

        public async Task<List<BankMaster>> GetBankNames()
        {
            List<BankMaster> BankMaster = null;
            try
            {

                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/GetBankNames";
                string cpath = url;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                HttpResponseMessage response = await httpClient.GetAsync(cpath);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var a = JsonConvert.DeserializeObject<List<BankMaster>>(response.Content.ReadAsStringAsync().Result);
                    BankMaster = a;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BankMaster;
        }



        public async Task<string> AddClaimRequest(AddClaimViewModel _claimdetails)
        {
            RequestCreateDTO reImClaimdetails = null;
            string status = "false";
            try
            {
                reImClaimdetails = GetRequestModel(_claimdetails);
                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/AddClaimRequest_New";
                string cpath = url;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var content = JsonConvert.SerializeObject(reImClaimdetails);

                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var a = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    status = a;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }


        #endregion




        private RequestCreateDTO GetRequestModel(AddClaimViewModel addClaimViewModel)
        {
            RequestCreateDTO _clmdet = null;
            List<RequestFileDTO> _uploadedfiles = null;
            List<Registration> _allusers = CustomerHandler.GetUsers();
            Registration _userdetails = _allusers.Find(c => c.Iqama_NationalID == addClaimViewModel.ClientDTO.IDNumber);
            if (addClaimViewModel != null)
            {
                _clmdet = new RequestCreateDTO();
                _clmdet.PolicyNumber = _userdetails.PolicyNo;
                _clmdet.HolderName = _userdetails.MemberName;
                _clmdet.MemberID = addClaimViewModel.ClientDTO.IDNumber;
                _clmdet.MemberName = _userdetails.MemberName;
                _clmdet.NationalId = addClaimViewModel.NationalId;
                _clmdet.RelationName = "";
                _clmdet.ClaimTypeName = addClaimViewModel.ClaimTypeName;
                _clmdet.CardNumber = _userdetails.CardNo;
                _clmdet.CardExpireDate = null;
                _clmdet.RequestDate = DateTime.Now;
                _clmdet.ExpectedAmount = addClaimViewModel.ExpectedAmount;
                _clmdet.VATAmount = addClaimViewModel.VATAmount;
                _clmdet.Comment = addClaimViewModel.Comment;
                ClientDTO client = new ClientDTO();
                client.ClientName = _userdetails.MemberName;
                client.IDNumber = addClaimViewModel.ClientDTO.IDNumber;
                client.MobileNumber = _userdetails.MemberMobileNumber;
                client.Email = "";
                client.IBANNumber = addClaimViewModel.ClientDTO.IB0+addClaimViewModel.ClientDTO.IB1 + addClaimViewModel.ClientDTO.IB2 + addClaimViewModel.ClientDTO.IB3 + addClaimViewModel.ClientDTO.IB4 + addClaimViewModel.ClientDTO.IB5 + addClaimViewModel.ClientDTO.IB6;
                client.BankName = addClaimViewModel.ClientDTO.BankName;
                _clmdet.ClientDTO = client;

                _uploadedfiles = new List<RequestFileDTO>();
                foreach (var file in addClaimViewModel.FilesUploaded)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            RequestFileDTO requestFile = new RequestFileDTO();
                            requestFile.FileDesc = file.FileName;                            
                            requestFile.FilePath = file.FileName;
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            string s = Convert.ToBase64String(fileBytes);
                            requestFile.MyFile = fileBytes;
                            // act on the Base64 data
                            _uploadedfiles.Add(requestFile);
                        }
                    }
                }
                _clmdet.RequestFileList = _uploadedfiles;
            }

            return _clmdet;
        }

        public async  Task<string> UpdateClaimRequest(ReClaimsDetails clm)
        {
            UpdateClaimRequest reImClaimdetails = null;
            string status = "false";
            try
            {
                reImClaimdetails = GetUpdateRequestModel(clm);
                HttpMessageHandler handler = new HttpClientHandler();
                string url = "https://localhost:44328/api/UpdateClaim";
                string cpath = url;
                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(cpath),
                    Timeout = new TimeSpan(0, 2, 0)
                };
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var content = JsonConvert.SerializeObject(reImClaimdetails);

                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var a = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    status = a;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        private UpdateClaimRequest GetUpdateRequestModel(ReClaimsDetails _updatedetails)
        {
            UpdateClaimRequest _clmdet = null;
            List<RequestFileDTO> _uploadedfiles = null;
            if (_updatedetails != null)
            {
                _clmdet = new UpdateClaimRequest();
                _clmdet.RequestId = Convert.ToInt32(_updatedetails.RequestCreateDTO.RequestNumber);
                _clmdet.Comment = _updatedetails.RequestCreateDTO.Comment;

                _uploadedfiles = new List<RequestFileDTO>();
                foreach (var file in _updatedetails.FilesUploaded)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            RequestFileDTO requestFile = new RequestFileDTO();
                            requestFile.FileDesc = file.FileName;
                            requestFile.FilePath = file.FileName;
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            string s = Convert.ToBase64String(fileBytes);
                            requestFile.MyFile = fileBytes;
                            // act on the Base64 data
                            _uploadedfiles.Add(requestFile);
                        }
                    }
                }
                _clmdet.RequestFileList = _uploadedfiles;
            }

            return _clmdet;
        }
    }

}