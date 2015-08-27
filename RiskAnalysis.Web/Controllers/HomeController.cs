using System.Web.Mvc;
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

            return View();
        }
    }
}
