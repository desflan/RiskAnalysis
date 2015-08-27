using RiskAnalysis.DataAccess.Models;
using RiskAnalysis.DataAccess.Seed;

namespace RiskAnalysis.DataAccess.Migrations
{
    public class SeedUtilities
    {
        private readonly RiskContext _context;

        public SeedUtilities(RiskContext context)
        {
            _context = context;
        }

        public void InsertData()
        {
            var dataMigration = new DataMigration(_context);
            dataMigration.InsertData();
        }
    }
}
