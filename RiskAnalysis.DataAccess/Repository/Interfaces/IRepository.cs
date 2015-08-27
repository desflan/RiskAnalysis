using System.Collections.Generic;

namespace RiskAnalysis.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
    }
}
