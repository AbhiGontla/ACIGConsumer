using Core.Domain;
using Core.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        public void Insert(Customer customer);

        public Registration ValidateCustomer(string NId,string Pin);
        public Registration GetCustomerById(string NId);

        public void Insert(Registration _userregistration);
    }
}
