namespace RiskAnalysis.Services.DTO
{
    public  class BetModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public decimal Stake { get; set; }
        public string CustomerName { get; set; }
    }
}
