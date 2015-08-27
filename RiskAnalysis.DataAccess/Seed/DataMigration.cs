using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskAnalysis.DataAccess.Models;
using System.Data.Entity.Migrations;
using RiskAnalysis.Domain.Entities;

namespace RiskAnalysis.DataAccess.Seed
{
    public class DataMigration
    {
        private readonly RiskContext _context;

        public DataMigration(RiskContext context)
        {
            _context = context;
        }

        public void InsertData()
        {
            InsertCustomers();
        }

        private void InsertCustomers()
        {
            _context.Customers.AddOrUpdate(c => c.Fullname, new Customer {Fullname = "Tom White"},
                                           new Customer {Fullname = "Jack Smith"},
                                           new Customer {Fullname = "David Gills"},
                                           new Customer {Fullname = "Frank Thompson"},
                                           new Customer {Fullname = "James Regan"},
                                           new Customer {Fullname = "Bill Jones"});

            _context.SaveChanges();
        }
    }
}
