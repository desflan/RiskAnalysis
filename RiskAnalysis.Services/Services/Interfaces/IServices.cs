namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface IServices
    {
        ICustomerService CustomerService { get; }
        ISettledBetService SettledBetService { get; }
        IUnsettledBetService UnsettledBetService { get; }
    }
}
