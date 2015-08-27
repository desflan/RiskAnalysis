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

        [TestMethod]
        public void When_Unusual_Customers_Do_Not_Exist_Then_No_UnSettled_Bets_Returned()
        {
            var betsFromUnusualCustomers = new BetsFromUnusualCustomers(new List<UnsettledBetModel>
				{
					new UnsettledBetModel
						{
							Id = 3,
							CustomerId = 1,
							CustomerName = string.Empty,
							EventId = 5,
							ParticipantId = 8,
							Stake = 50,
							ToWin = 200
						},
					new UnsettledBetModel
						{
							Id = 4,
							CustomerId = 2,
							CustomerName = string.Empty,
							EventId = 5,
							ParticipantId = 8,
							Stake = 50,
							ToWin = 400
						}
				}, new List<CustomerModel>());

            var calculator = new BetCalculatorService();
            var result = calculator.DoCalculation(betsFromUnusualCustomers);

            Assert.IsNull(result, "Unsettled Bets returned for unusual customers when unusual customers do not exist");
        }

        [TestMethod]
        public void When_No_Bets_10_Times_Higher_Than_Avg_Exist_Then_No_Records_Returned()
        {
            var betHigherThanAvg = new BetsHigherThanAvg(new List<UnsettledBetModel>
				{
					new UnsettledBetModel
						{
							Id = 3,
							CustomerId = 1,
							CustomerName = string.Empty,
							EventId = 5,
							ParticipantId = 8,
							Stake = 750,
							ToWin = 3500
						},
					new UnsettledBetModel
						{
							Id = 4,
							CustomerId = 2,
							CustomerName = string.Empty,
							EventId = 5,
							ParticipantId = 8,
							Stake = 450,
							ToWin = 900
						}
				}, new List<CustomerModel>
					{
						new CustomerModel {Id = 1, Fullname = string.Empty, AverageBet = 100},
						new CustomerModel {Id = 2, Fullname = string.Empty, AverageBet = 50}
					}, 10);


            var calculator = new BetCalculatorService();
            var result = calculator.DoCalculation(betHigherThanAvg);

            Assert.IsNull(result, "Zero not returned when higher than average bets do not exist");
        }
    }
}