using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerModel> GetAllCustomers();
    }
}