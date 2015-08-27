using System.Collections.Generic;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;

namespace RiskAnalysis.Services.Services.Calculator.Interfaces
{
    public interface IBetCalculatorService
    {
        List<UnsettledBetModel> DoCalculation(IBetRisk entity);
    }
}