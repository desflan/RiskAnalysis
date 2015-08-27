using System.Collections.Generic;

namespace RiskAnalysis.Domain.Entities
{
    public class Customer
    {
        private ICollection<UnsettledBet> _unsettledBets;
        private ICollection<SettledBet> _settledBets;

        public Customer()
        {
            _unsettledBets = new List<UnsettledBet>();
            _settledBets =new List<SettledBet>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public decimal AverageBet { get; set; }

        public virtual ICollection<UnsettledBet> UnsettledBets
        {
            get { return _unsettledBets; }
            set { _unsettledBets = value; }
        }
        public virtual ICollection<SettledBet> SettledBets
        {
            get { return _settledBets; }
            set { _settledBets = value; }
        }
    }
}
