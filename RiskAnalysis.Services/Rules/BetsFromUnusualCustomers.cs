using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;

namespace RiskAnalysis.Services.Rules
{
    public class BetsFromUnusualCustomers : IBetRisk
    {
        private readonly IEnumerable<UnsettledBetModel> _unsettledBets;
        private readonly IEnumerable<CustomerModel> _customers;

        public BetsFromUnusualCustomers(IEnumerable<UnsettledBetModel> unsettledBets, IEnumerable<CustomerModel> customers)
        {
            _unsettledBets = unsettledBets;
            _customers = customers;
        }

        public List<UnsettledBetModel> ProcessBets()
        {
            if (_customers != null)
            {
                var unusualBets = _unsettledBets.Where(b => _customers.Any(c => c.Id == b.CustomerId));
                return unusualBets.Any() ? unusualBets.ToList() : null;
            }

            return null;
        }
    }
}
