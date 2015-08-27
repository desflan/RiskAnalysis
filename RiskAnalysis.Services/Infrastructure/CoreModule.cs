﻿using System.Data.Entity;
using Autofac;
using Autofac.Extras.AggregateService;
using RiskAnalysis.DataAccess.Models;
using RiskAnalysis.DataAccess.Models.Interfaces;
using RiskAnalysis.Services.Services;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Services.Infrastructure
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RiskContext>().As<IRiskContext>().InstancePerRequest();
            builder.RegisterType<RiskContext>().As<DbContext>().InstancePerRequest();

            builder.RegisterAggregateService<IServices>();

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<SettledBetService>().As<ISettledBetService>();
            builder.RegisterType<UnsettledBetService>().As<IUnsettledBetService>();


            base.Load(builder);

        }

    }
}
