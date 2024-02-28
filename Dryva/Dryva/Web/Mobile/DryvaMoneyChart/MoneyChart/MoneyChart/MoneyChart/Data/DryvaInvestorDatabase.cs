using MoneyChart.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChart.Data
{
    public class DryvaInvestorDatabase
    {
        IRestService restService;
        public DryvaInvestorDatabase(IRestService service)
        {
            restService = service;
        }

        #region Read from

        public Task<List<CustomerReportDTO>> GetCustomerReportDTOAsync()
        {
            return restService.GetCustomerReportDTOAsync();
        }

        public Task<List<SubscriberReportDTO>> GetSubscriberReportDTOAsync()
        {
            return restService.GetSubscriberReportDTOAsync();
        }

        public Task<InvestorDTO> GetInvestorDTOAsync()
        {
            return restService.GetInvestorDTOAsync();
        }

        public Task<InvestorProfitDTO> GetInvestorProfitDTOAsync()
        {
            return restService.GetInvestorProfitDTOAsync();
        }
        #endregion
    }
}
