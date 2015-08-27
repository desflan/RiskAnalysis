using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;

namespace RiskAnalysis.Services.Rules
{
    public class UnusualWinRate : ICustomerRisk
    {
        private readonly IEnumerable<CustomerModel> _customers;
        private readonly IEnumerable<SettledBetModel> _settledBets;

        public UnusualWinRate(IEnumerable<CustomerModel> customers, IEnumerable<SettledBetModel> settledBets )
        {
            _customers = customers;
            _settledBets = settledBets;
        }

        public List<CustomerModel> ProcessCustomers()
        {
            const int winPercent = 60;

            var numBetsPerCustomer = _settledBets.GroupBy(c => c.CustomerId, sb => sb.Win,
                                                          (key, w) => new {CustomerId = key, BetCount = w.Count()});


            var numWinsPerCustomer = _settledBets.Where(sb => sb.Win > 0).GroupBy(c => c.CustomerId, sb => sb.Win,
                                                          (key, w) => new { CustomerId = key, WinCount = w.Count() });

            var betsAndWinsPerCustomer = numBetsPerCustomer.Join(numWinsPerCustomer, b => b.CustomerId,
                                                                 w => w.CustomerId, (totalBets, totalWins) => new
                                                                     {
                                                                         CustomerId = totalBets.CustomerId,
                                                                         TotalBets = totalBets.BetCount,
                                                                         TotalWins = totalWins.WinCount
                                                                     });


            var result = betsAndWinsPerCustomer.Where(tb => tb.TotalWins*100/tb.TotalBets > winPercent).Select(
                c =>
                new CustomerModel {Id = c.CustomerId, Fullname = _customers.Single(a => a.Id == c.CustomerId).Fullname});


            return result.Any() ? result.ToList() : null;
        }
    }
}
