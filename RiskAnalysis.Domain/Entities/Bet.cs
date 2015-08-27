namespace RiskAnalysis.Domain.Entities
{
    public abstract class Bet
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public decimal Stake { get; set; }
        
        public virtual Customer Customer { get; set; }
    }
}
