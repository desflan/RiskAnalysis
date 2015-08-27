using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Rules.Interfaces
{
    public interface ICustomerRisk
    {
        List<CustomerModel> ProcessCustomers();
    }
}
