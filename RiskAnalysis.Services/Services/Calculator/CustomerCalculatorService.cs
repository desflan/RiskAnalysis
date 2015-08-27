using System.Collections.Generic;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;
using RiskAnalysis.Services.Services.Calculator.Interfaces;

namespace RiskAnalysis.Services.Services.Calculator
{
    public class CustomerCalculatorService : ICustomerCalculatorService
    {
        public List<CustomerModel> DoCalculation(ICustomerRisk entity)
        {
            return entity.ProcessCustomers();
        }
    }
}
