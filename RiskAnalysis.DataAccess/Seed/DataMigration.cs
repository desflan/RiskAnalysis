using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
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
            if (!_context.SettledBets.Any())
            {
                InsertCustomers();
                InsertSettledData();
                InsertUnsettledData();
                UpdateCustomers();
            }
        }

        private void UpdateCustomers()
        {
            var customers = _context.Customers;

            foreach (var customer in customers)
            {
                customer.AverageBet = customer.SettledBets.Average(sb => sb.Stake);
            }

            _context.SaveChanges();

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

        private void InsertUnsettledData()
        {
            string unsettledData = ConfigurationManager.AppSettings["CsvUnsettled"];

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(unsettledData);
            if (stream != null)
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var data = csvReader.GetRecords<UnsettledBet>().ToArray();
                    foreach (var unsettled in data)
                    {
                        unsettled.Customer = null;
                    }
                    _context.UnsettledBets.AddOrUpdate(c => c.Id, data);
                    _context.SaveChanges();
                }

        }

        private void InsertSettledData()
        {
            var settledData = ConfigurationManager.AppSettings["CsvSettled"];

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(settledData);
            if (stream != null)
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    var data = csvReader.GetRecords<SettledBet>().ToArray();
                    foreach (var settled in data)
                    {
                        settled.Customer = null;
                    }
                    _context.SettledBets.AddOrUpdate(c => c.Id, data);
                    _context.SaveChanges();
                }
        }


    }
}
