using System.Collections.Generic;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules;
using RiskAnalysis.Services.Services.Calculator.Interfaces;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Services.Services
{
    public class CustomerAnalysisService : ICustomerAnalysisService
    {
        private readonly ICustomerCalculatorService _calculator;

        public CustomerAnalysisService(ICustomerCalculatorService calculator )
        {
            _calculator = calculator;
        }

        public List<CustomerModel> GetUnusualCustomers(IEnumerable<CustomerModel> customers, IEnumerable<SettledBetModel> settledBets)
        {
            var highWinRate = new HighWinRate(customers, settledBets);

            return _calculator.DoCalculation(highWinRate);
        }
    }
}
