using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface IUnsettledBetAnalysisService
    {
        List<UnsettledBetModel> GetBetsFromUnusualCustomers(IEnumerable<CustomerModel> customers,
                                                                            IEnumerable<UnsettledBetModel> unsettledBets);

        List<UnsettledBetModel> GetBetsWithStake10TimesAboveAvg(IEnumerable<CustomerModel> customers,
                                                                IEnumerable<UnsettledBetModel> unsetteledBets);
        List<UnsettledBetModel> GetBetsWithStake30TimesAboveAvg(IEnumerable<CustomerModel> customers,
                                                                IEnumerable<UnsettledBetModel> unsetteledBets);

        List<UnsettledBetModel> GetBetsWithLargeWinAmount(IEnumerable<UnsettledBetModel> unsetteledBets);
    }
}