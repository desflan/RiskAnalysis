using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface IUnsettledBetAnalysisService
    {
        List<UnsettledBetModel> GetBetsFromUnusualCustomers(IEnumerable<CustomerModel> customers,
                                                                            IEnumerable<UnsettledBetModel> unsettledBets);
    }
}