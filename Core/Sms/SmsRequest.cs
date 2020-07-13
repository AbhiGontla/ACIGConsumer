using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Core.Sms
{
    public class SmsRequest
    {
        WebRequest _objWebRequest;
        WebResponse _objResponse;
        Stream _objStream;
        StreamReader _objStreamReader;
        SmsResponse _objJsonResponse;
        string _status, _url, _userName, _password, _senderName, _postData, _mobileNumber, _message, _response;
        byte[] _bytArray;
        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }


        public string SmsHandler(string mobileNumber, string message)
        {
            _mobileNumber = mobileNumber;
            _message = HttpUtility.UrlEncode(message);
            return SendSms();
        }

        public string SendSms()
        {
            try
            {
                AssignInitialData();
                BuildPostData();
                SendRequest();
                ParseRequest();
            }
            catch (Exception e)
            {
                _response = e.Message;
                if (e.InnerException != null)
                {
                    _response += " " + e.InnerException.Message;
                }
            }
            return _response;
        }

        void AssignInitialData()
        {
            _url = "http://ht.ruh2.cequens.sa/send.aspx";
            _userName = "ACIG-APP";
            _password = "Pass2017";
            _senderName = "ACIG";
        }

        void BuildPostData()
        {
            _postData = "UserName=" + _userName + "&Password=" + _password + "&SenderName=" + _senderName + "&MessageType=Text&Recipients=" + _mobileNumber + "&MessageText=" + _message;
        }

        void SendRequest()
        {
            _objWebRequest = (HttpWebRequest)WebRequest.Create(_url);
            _bytArray = Encoding.ASCII.GetBytes(_postData);
            _objWebRequest.Method = "POST";
            _objWebRequest.ContentType = "application/x-www-form-urlencoded";
            _objWebRequest.ContentLength = _bytArray.Length;
            using (var stream = _objWebRequest.GetRequestStream())
            {
                stream.Write(_bytArray, 0, _bytArray.Length);
            }
        }

        string ParseRequest()
        {
            _objResponse = (HttpWebResponse)_objWebRequest.GetResponse();
            _response = new StreamReader(_objResponse.GetResponseStream()).ReadToEnd();
            _objJsonResponse = JsonConvert.DeserializeObject<SmsResponse>(_response);
            _response = ConvertResponseCode();
            //Console.WriteLine("Client ID " + _objJsonResponse.requestStatus.ClientMessageID);
            //Console.WriteLine("Request ID " + _objJsonResponse.requestStatus.RequestID);
            //Console.WriteLine("Response ID " + _objJsonResponse.requestStatus.ResponseText);
            return _response;
        }

        string ConvertResponseCode()
        {
            var ConvertedResponse = "success";
            if (_objJsonResponse.errors.Count > 0)
            {
                ConvertedResponse = _objJsonResponse.errors.ToString();
            }
            switch (ConvertedResponse)
            {
                case "success":
                    ConvertedResponse = "Success";
                    break;
                case "-1":
                    ConvertedResponse = "Authentication Failed";
                    break;
                case "-2":
                    ConvertedResponse = "Invalid Validity Period";
                    break;
                case "-3":
                    ConvertedResponse = "No Recipients";
                    break;
                case "-4":
                    ConvertedResponse = "Invalid Recipient Number";
                    break;
                case "-5":
                    ConvertedResponse = "Invalid Client Message";
                    break;
                case "-6":
                    ConvertedResponse = "Empty Message";
                    break;
                case "-7":
                    ConvertedResponse = "Invalid Message Type";
                    break;
                case "-8":
                    ConvertedResponse = "Invalid Delivery Time";
                    break;
                case "-9":
                    ConvertedResponse = "Invalid Sender Name";
                    break;
                case "-10":
                    ConvertedResponse = "Not sent for recipient";
                    break;
                case "-12":
                    ConvertedResponse = "Not enough credits";
                    break;
                case "-15":
                    ConvertedResponse = "Flashing should be 0 or 1";
                    break;
                case "-16":
                    ConvertedResponse = "Invalid Unicode Data";
                    break;
                case "-18":
                    ConvertedResponse = "Acknowledgment should be 0 or 1";
                    break;
            }
            return ConvertedResponse;
        }

    }
}
