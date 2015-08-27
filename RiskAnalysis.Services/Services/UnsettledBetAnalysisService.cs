using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules;
using RiskAnalysis.Services.Services.Calculator.Interfaces;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Services.Services
{
    public class UnsettledBetAnalysisService : IUnsettledBetAnalysisService
    {
        private readonly IBetCalculatorService _calculator;

        public UnsettledBetAnalysisService(IBetCalculatorService calculator)
        {
            _calculator = calculator;
        }

        public List<UnsettledBetModel> GetBetsFromUnusualCustomers(IEnumerable<CustomerModel> customers,
                                                                   IEnumerable<UnsettledBetModel> unsettledBets)
        {
            var bets = new BetsFromUnusualCustomers(unsettledBets, customers);
            return _calculator.DoCalculation(bets);
        }

        public List<UnsettledBetModel> GetBetsWithStake10TimesAboveAvg(IEnumerable<CustomerModel> customers, IEnumerable<UnsettledBetModel> unsetteledBets)
        {
            const int multiplier = 10;

            var betsAboveAvg = new BetsHigherThanAvg(unsetteledBets, customers, multiplier);
            var result = _calculator.DoCalculation(betsAboveAvg);

            return result;
        }
    }
}
