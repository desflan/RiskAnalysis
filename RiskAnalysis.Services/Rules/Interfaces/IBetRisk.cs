using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Rules.Interfaces
{
    public interface IBetRisk
    {
        List<UnsettledBetModel> ProcessBets();
    }
}
