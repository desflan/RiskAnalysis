using System.Web.Mvc;
using RiskAnalysis.Services.DTO;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServices services)
            : base(services)
        { }
        
        public ActionResult Index()
        {
            var customers = Services.CustomerService.GetAllCustomers();
            var settledBets = Services.SettledBetService.GetAllBets();
            var unsettledBets = Services.UnsettledBetService.GetAllBets();

            var model = new SummaryDataModel();

            model.CustomersWithHighWinRate = Services.CustomerAnalysisService.GetUnusualCustomers(customers, settledBets);
            model.BetsFromUnusualCustomers =
                Services.UnsettledBetAnalysisService.GetBetsFromUnusualCustomers(model.CustomersWithHighWinRate, unsettledBets);
            model.Bet10TimesHigherThanAvg = Services.UnsettledBetAnalysisService.GetBetsWithStake10TimesAboveAvg(customers,
                                                                                                           unsettledBets);
            model.Bet30TimesHigherThanAvg = Services.UnsettledBetAnalysisService.GetBetsWithStake30TimesAboveAvg(customers,
                                                                                                           unsettledBets);
            model.BetsWithHighWinAmount = Services.UnsettledBetAnalysisService.GetBetsWithLargeWinAmount(unsettledBets);


            return View(model);
        }
    }
}
