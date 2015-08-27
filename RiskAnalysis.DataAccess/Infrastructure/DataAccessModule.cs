using Autofac;
using RiskAnalysis.DataAccess.Repository;
using RiskAnalysis.DataAccess.Repository.Interfaces;

namespace RiskAnalysis.DataAccess.Infrastructure
{
    public  class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RiskAnalysisRepository<>)).As(typeof(IRepository<>));
        }
    }
}