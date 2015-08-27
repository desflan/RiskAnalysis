using AutoMapper;
using Autofac;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.Services.DTO
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public decimal AverageBet { get; set; }
    }

    public class AddCustomerMapping : IStartable
    {
        public void Start()
        {
            Mapper.CreateMap<Customer, CustomerModel>();
        }
    }
}