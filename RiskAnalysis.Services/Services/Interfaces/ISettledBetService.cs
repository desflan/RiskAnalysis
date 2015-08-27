using System.Collections.Generic;
using RiskAnalysis.Services.DTO;

namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface ISettledBetService
    {
        List<SettledBetModel> GetAllBets();
    }
}