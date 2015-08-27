using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface ICustomerAnalysisService
    {
        List<CustomerModel> GetUnusualCustomers(IEnumerable<CustomerModel> customers, IEnumerable<SettledBetModel> settledBets);
    }
}