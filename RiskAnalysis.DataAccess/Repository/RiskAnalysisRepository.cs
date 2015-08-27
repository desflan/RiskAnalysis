using System.Collections.Generic;
using System.Data.Entity;
using RiskAnalysis.DataAccess.Models.Interfaces;
using RiskAnalysis.DataAccess.Repository.Interfaces;

namespace RiskAnalysis.DataAccess.Repository
{
    public class RiskAnalysisRepository<T> : IRepository<T> where T : class
    {
        protected internal DbContext Context;
        protected internal DbSet<T> DbSet;

        public RiskAnalysisRepository(IRiskContext context)
        {
            Context = context as DbContext;
            if (Context != null) DbSet = Context.Set<T>();
        }

        public virtual IEnumerable<T> FindAll()
        {
            return DbSet;
        }
    }
}
