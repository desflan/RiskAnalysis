using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RiskAnalysis.DataAccess.Repository.Interfaces;
using RiskAnalysis.Domain.Entities;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository )
        {
            _repository = repository;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var customers = _repository.FindAll();
            return Mapper.Map<List<CustomerModel>>(customers);
        }
    }
}
