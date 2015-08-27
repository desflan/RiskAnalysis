using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RiskAnalysis.DataAccess.Repository.Interfaces;
using RiskAnalysis.Domain.Entities;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Services.Services
{
   public class SettledBetService : ISettledBetService
   {
       private readonly IRepository<SettledBet> _repository;

       public SettledBetService(IRepository<SettledBet> repository )
       {
           _repository = repository;
       }

       public List<SettledBetModel> GetAllBets()
       {
           var bets = _repository.FindAll();
           return Mapper.Map<List<SettledBetModel>>(bets);
       }
    }
}
