using System.Collections.Generic;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;
using RiskAnalysis.Services.Services.Calculator.Interfaces;

namespace RiskAnalysis.Services.Services.Calculator
{
    public class BetCalculatorService : IBetCalculatorService
    {
        public List<UnsettledBetModel> DoCalculation(IBetRisk entity)
        {
            return entity.ProcessBets();
        }
    }
}
