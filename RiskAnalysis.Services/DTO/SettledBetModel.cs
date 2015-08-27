using AutoMapper;
using Autofac;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.Services.DTO
{
    public class SettledBetModel : BetModel
    {
        public decimal Win { get; set; }
    }

    public class AddSettledMapping : IStartable
    {
        public void Start()
        {
            Mapper.CreateMap<SettledBet, SettledBetModel>()
                            .ForMember(o => o.CustomerName, m => m.MapFrom(t => t.Customer.Fullname));
        }
    }
}
