using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Customer
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
    }
}
