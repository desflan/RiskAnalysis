using System.Collections.Generic;

namespace RiskAnalysis.Services.DTO
{
    public class SummaryDataModel
    {
        public List<CustomerModel> CustomersWithHighWinRate { get; set; }
        public List<UnsettledBetModel> BetsFromUnusualCustomers { get; set; }
        public List<UnsettledBetModel> Bet10TimesHigherThanAvg { get; set; }
        public List<UnsettledBetModel> Bet30TimesHigherThanAvg { get; set; }
        public List<UnsettledBetModel> BetsWithHighWinAmount { get; set; }
    }
}
