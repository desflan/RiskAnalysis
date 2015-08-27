using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskAnalysis.Services.Services.Interfaces
{
    public interface IServices
    {
        ICustomerService CustomerService { get; }
    }
}
