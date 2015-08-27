using System.Collections.Generic;
using System.Linq;
using RiskAnalysis.DataAccess.Models;
using RiskAnalysis.DataAccess.Repository.Interfaces;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.DataAccess.Repository
{
    public class UnsettledBetRepository : IRepository<UnsettledBet>
    {
        private readonly RiskContext _context;

        public UnsettledBetRepository(RiskContext context)
        {
            _context = context;
        }

        public IEnumerable<UnsettledBet> FindAll()
        {
            return _context.UnsettledBets.ToList();
        }
    }
}
