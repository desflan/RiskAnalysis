using System.Web.Mvc;
using RiskAnalysis.Services.Services.Interfaces;

namespace RiskAnalysis.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IServices Services;
        
        public BaseController(IServices services)
        {
            Services = services;
        }
    }
}