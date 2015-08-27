using System.Collections.Generic;
using System.Linq;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;

namespace RiskAnalysis.Services.Rules
{
    public  class LargeWinAmount : IBetRisk
    {
        private readonly IEnumerable<UnsettledBetModel> _unsettledBets;

        public LargeWinAmount(IEnumerable<UnsettledBetModel> unsettledBets)
        {
            _unsettledBets = unsettledBets;
        }

        public List<UnsettledBetModel> ProcessBets()
        {
            const int largeWinAmount = 1000;
            var bets = _unsettledBets.Where(b => b.ToWin >= largeWinAmount);
            return bets.Any() ? bets.ToList() : null;
        }
    }
}
