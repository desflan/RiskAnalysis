using System.Collections.Generic;
using AutoMapper;
using RiskAnalysis.DataAccess.Repository.Interfaces;
using RiskAnalysis.Domain.Entities;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Services.Services
{
    public class UnsettledBetService : IUnsettledBetService
    {
         private readonly IRepository<UnsettledBet> _repository;

       public UnsettledBetService(IRepository<UnsettledBet> repository )
       {
           _repository = repository;
       }

       public List<UnsettledBetModel> GetAllBets()
       {
           var bets = _repository.FindAll();
           return Mapper.Map<List<UnsettledBetModel>>(bets);
       }
    }
}
