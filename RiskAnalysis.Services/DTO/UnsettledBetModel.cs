using AutoMapper;
using Autofac;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.Services.DTO
{
    public class UnsettledBetModel : BetModel
    {
        public decimal ToWin { get; set; }
    }

    public class AddUnsettledMapping : IStartable
    {
        public void Start()
        {
            Mapper.CreateMap<UnsettledBet, UnsettledBetModel>()
                            .ForMember(o => o.CustomerName, m => m.MapFrom(t => t.Customer.Fullname));
        }
    }
}
