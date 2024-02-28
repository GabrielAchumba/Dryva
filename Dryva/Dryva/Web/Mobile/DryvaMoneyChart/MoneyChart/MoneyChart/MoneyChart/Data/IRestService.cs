using MoneyChart.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChart.Data
{
    public interface IRestService
    {
        Task<List<CustomerReportDTO>> GetCustomerReportDTOAsync();
        Task<List<SubscriberReportDTO>> GetSubscriberReportDTOAsync();
        Task<InvestorDTO> GetInvestorDTOAsync();
        Task<InvestorProfitDTO> GetInvestorProfitDTOAsync();


    }
}
