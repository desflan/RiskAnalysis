using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules.Interfaces;

namespace RiskAnalysis.Services.Rules
{
    public class BetsHigherThanAvg : IBetRisk 
    {
        private readonly IEnumerable<UnsettledBetModel> _unsettledBets;
        private readonly IEnumerable<CustomerModel> _customers;
        private readonly int _multiplier;

        public BetsHigherThanAvg(IEnumerable<UnsettledBetModel> unsettledBets, IEnumerable<CustomerModel> customers, int multiplier)
        {
            _unsettledBets = unsettledBets;
            _customers = customers;
            _multiplier = multiplier;
        }

        public List<UnsettledBetModel> ProcessBets()
        {
            var customerBets = _unsettledBets.Join(_customers, ub => ub.CustomerId, c => c.Id,
                    (unsettled, customers) =>
                    new
                        {
                            BetId = unsettled.Id,
                            CustomerId = customers.Id,
                            EventId = unsettled.EventId,
                            ParticipantId = unsettled.ParticipantId,
                            Avg = customers.AverageBet,
                            Stake = unsettled.Stake,
                            CustomerName = customers.Fullname,
                            ToWin = unsettled.ToWin
                        });

            var bets = customerBets.Where(cb => cb.Stake > cb.Avg * _multiplier).Select(
                ub => new UnsettledBetModel
                    {
                        Id = ub.BetId,
                        CustomerId = ub.CustomerId,
                        CustomerName = ub.CustomerName,
                        EventId = ub.EventId,
                        ParticipantId = ub.ParticipantId,
                        Stake = ub.Stake,
                        ToWin = ub.ToWin
                    });

            return bets.Any() ? bets.ToList() : null;
        }
    }
}
