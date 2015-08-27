using System.Collections.Generic;
using System.Linq;
using RiskAnalysis.DataAccess.Models;
using RiskAnalysis.DataAccess.Models.Interfaces;
using RiskAnalysis.DataAccess.Repository.Interfaces;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.DataAccess.Repository
{
    public class SettledBetRepository : IRepository<SettledBet>
    {
        private readonly RiskContext _context;

        public SettledBetRepository(RiskContext context)
        {
            _context = context;
        }

        public IEnumerable<SettledBet> FindAll()
        {
            var settledBets = _context.SettledBets.ToList();
            return settledBets;
        }
    }
}
