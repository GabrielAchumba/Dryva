using MoneyChart.DTOs;
using MoneyChart.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoneyChart
{
    public class TestData
    {
        public TestData()
        {
            GetInvestorDTO();
            GetSubscribersDTO();
            GetCustomerRegistrationDTOList();
            GetInvestorProfitDTOList();
        }
        public InvestorDTO investorDTO { get; set; }
        public ObservableCollection<SubscriberReportDTO> subscriberReportDTO { get; set; }

        public ObservableCollection<CustomerReportDTO> customerReportDTO { get; set; }
        public InvestorProfitDTO InvestorProfitDTO { get; set; }
        private void GetInvestorDTO()
        {
            investorDTO = new InvestorDTO()
            {
                Title = "Mr.",
                FirstName = "Gabriel",
                OtherName = "Ifeanyi",
                Surname = "Achumba",
                Gender = "M",
                Percentage = Convert.ToDecimal(0.4),
                Pin = 1234
            };
        }

        private void GetSubscribersDTO()
        {
            subscriberReportDTO = new ObservableCollection<SubscriberReportDTO>();
            SubscriberReportDTO subscribersDTO = new SubscriberReportDTO();
            subscribersDTO.State = "Akwa Ibom";
            subscribersDTO.LGA = "Uyo";
            subscribersDTO.CustomerCount = 18000;
            subscribersDTO.Amount = 18000 * 2500;
            subscriberReportDTO.Add(subscribersDTO);
            subscribersDTO = new SubscriberReportDTO();
            subscribersDTO.State = "Akwa Ibom";
            subscribersDTO.LGA = "Eket";
            subscribersDTO.CustomerCount = 13000;
            subscribersDTO.Amount = 13000 * 2500;
            subscriberReportDTO.Add(subscribersDTO);
            subscribersDTO = new SubscriberReportDTO();
            subscribersDTO.State = "Akwa Ibom";
            subscribersDTO.LGA = "Oron";
            subscribersDTO.CustomerCount = 10000;
            subscribersDTO.Amount = 8000 * 2500;
            subscriberReportDTO.Add(subscribersDTO);


        }

        private void GetCustomerRegistrationDTOList()
        {
            customerReportDTO = new ObservableCollection<CustomerReportDTO>();
            CustomerReportDTO customerRegistrationDTO = new CustomerReportDTO();
            customerRegistrationDTO.State = "Akwa Ibom";
            customerRegistrationDTO.LGA = "Uyo";
            customerRegistrationDTO.CustomerCount = 20000;
            customerReportDTO.Add(customerRegistrationDTO);
            customerRegistrationDTO = new CustomerReportDTO();
            customerRegistrationDTO.State = "Akwa Ibom";
            customerRegistrationDTO.LGA = "Eket";
            customerRegistrationDTO.CustomerCount = 15000;
            customerReportDTO.Add(customerRegistrationDTO);
            customerRegistrationDTO = new CustomerReportDTO();
            customerRegistrationDTO.State = "Akwa Ibom";
            customerRegistrationDTO.LGA = "Oron";
            customerRegistrationDTO.CustomerCount = 10000;
            customerReportDTO.Add(customerRegistrationDTO);
        }

        private void GetInvestorProfitDTOList()
        {
            decimal ExpensesPercent =Convert.ToDecimal(0.08), 
                AssetsPercent = Convert.ToDecimal(0.12),
                LiabilityPercent = Convert.ToDecimal(0.20);

            InvestorProfitDTO = new InvestorProfitDTO();
            decimal capex = (18000 * 2500 + 13000 * 2500 + 8000 * 2500);
            InvestorProfitDTO.Capex = capex;
            InvestorProfitDTO.Opex = capex * Convert.ToDecimal(0.25);
            InvestorProfitDTO.PercentageRetainedProfit = 30;
            InvestorProfitDTO.Dividend = InvestorProfitDTO.Capex - InvestorProfitDTO.Opex;
            InvestorProfitDTO.Percentage = 6;
            InvestorProfitDTO.CurrentROI = InvestorProfitDTO.Dividend * InvestorProfitDTO.Percentage / 100;
            InvestorProfitDTO.CumulativeROI = InvestorProfitDTO.CurrentROI;
        }
    }
}
