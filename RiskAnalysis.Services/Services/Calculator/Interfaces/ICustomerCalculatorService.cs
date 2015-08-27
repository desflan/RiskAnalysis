using System.Collections.Generic;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;

namespace RiskAnalysis.Services.Services.Calculator.Interfaces
{
    public interface ICustomerCalculatorService
    {
        List<CustomerModel> DoCalculation(ICustomerRisk entity);
    }
}