using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RiskAnalysis.DataAccess.Extensions;
using RiskAnalysis.DataAccess.Migrations;
using RiskAnalysis.DataAccess.Models.Interfaces;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.DataAccess.Models
{
    public class RiskContext : DbContext, IRiskContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SettledBet> SettledBets { get; set; }
        public DbSet<UnsettledBet> UnsettledBets { get; set; }


        public RiskContext()
            : base("DefaultConnection")
        {
            if (System.Configuration.ConfigurationManager.AppSettings["DatabaseInitialisation"].ToBool())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<RiskContext, Configuration>());
            }
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
