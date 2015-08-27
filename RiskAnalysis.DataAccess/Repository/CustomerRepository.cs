using System.Collections.Generic;
using System.Linq;
using RiskAnalysis.DataAccess.Models;
using RiskAnalysis.DataAccess.Repository.Interfaces;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.DataAccess.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly RiskContext _context;

        public CustomerRepository(RiskContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> FindAll()
        {
            return _context.Customers.ToList();
        }
    }
}
