using Core.Domain;
using Core.Domain.Customer;
using Data;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWorks _unitOfWorks;

        public CustomerService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public Registration GetCustomerById(string NId)
        {
            var _customers = _unitOfWorks.RegistrationRepository.GetDbSet();
            return _customers.Where(c => (c.Iqama_NationalID == NId)).FirstOrDefault();
        }

        public void Insert(Customer customer)
        {
            _unitOfWorks.CustomerRepository.Insert(customer);
            _unitOfWorks.Save();
        }

        public void Insert(Registration _userregistration)
        {
            try
            {
                
                _unitOfWorks.RegistrationRepository.Insert(_userregistration);
                _unitOfWorks.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Registration ValidateCustomer(string NId, string Pin)
        {
            var _customers = _unitOfWorks.RegistrationRepository.GetDbSet();
            return _customers.Where(c => (c.Iqama_NationalID == NId) && (c.ConfirmPin == Pin)).FirstOrDefault();
        }
    }
}
