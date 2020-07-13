using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core
{
    public class GetLang
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        string langcode;
        string result;
        public GetLang(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           
        }
        public string GetLanguage()
        {            
            langcode = _httpContextAccessor.HttpContext.Request.Query["lang"];   
            if(langcode == null)
            {
                result = "en";
            }
            else
            {
                result = langcode;
            }
                     
            return result;
        }
    }
}
