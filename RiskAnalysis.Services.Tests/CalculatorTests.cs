using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Rules;
using RiskAnalysis.Services.Services.Calculator;

namespace RiskAnalysis.Services.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void When_Unusual_Customers_Exist_Then_Customer_Count_Is_Correct()
        {
            var highWinRate = new HighWinRate(new List<CustomerModel>
                {
                    new CustomerModel {Id = 1, Fullname = string.Empty, AverageBet = 100},
                    new CustomerModel {Id = 2, Fullname = string.Empty, AverageBet = 50}
                },
                new List<SettledBetModel>
                    {
                        new SettledBetModel  { Id = 3,  CustomerId = 1, CustomerName = string.Empty, EventId = 5, ParticipantId = 8, Stake = 50, Win = 200
                            },
                        new SettledBetModel { Id = 3, CustomerId = 2, CustomerName = string.Empty, EventId = 5,ParticipantId = 8, Stake = 50, Win = 400 },
                        new SettledBetModel { Id = 5, CustomerId = 2, CustomerName = string.Empty,EventId = 5, ParticipantId = 8,Stake = 50, Win = 0 }
                    }
                );
            
            var calculator = new CustomerCalculatorService();
            var result = calculator.DoCalculation(highWinRate);

            Assert.AreEqual(result.Count, 1, "Incorrect number of customers with high win rate returned");
        }
    }
}
