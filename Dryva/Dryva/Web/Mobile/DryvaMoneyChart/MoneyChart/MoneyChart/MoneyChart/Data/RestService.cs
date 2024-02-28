using MoneyChart.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChart.Data
{
    public class RestService: IRestService
    {
        
        public RestService()
        {
            #region _clientRegistration
            _clientRegistration = new HttpClient();
            string baseUrlRegistration = "http://d3c70764.ngrok.io/";
            _clientRegistration = new HttpClient();
            _clientRegistration.BaseAddress = new System.Uri(baseUrlRegistration);
            _clientRegistration.DefaultRequestHeaders.Clear();
            _clientRegistration.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientCapexOpex
            _clientCapexOpex = new HttpClient();
            string baseUrlCapexOpex = "http://d3c70764.ngrok.io/";
            _clientCapexOpex = new HttpClient();
            _clientCapexOpex.BaseAddress = new System.Uri(baseUrlCapexOpex);
            _clientCapexOpex.DefaultRequestHeaders.Clear();
            _clientCapexOpex.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientInvestorProfit
            _clientInvestorProfit = new HttpClient();
            string baseUrlInvestorProfit = "http://d3c70764.ngrok.io/";
            _clientInvestorProfit = new HttpClient();
            _clientInvestorProfit.BaseAddress = new System.Uri(baseUrlInvestorProfit);
            _clientInvestorProfit.DefaultRequestHeaders.Clear();
            _clientInvestorProfit.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientCustomers
            _clientCustomers = new HttpClient();
            string baseUrlCustomers = "http://d3c70764.ngrok.io/";
            _clientCustomers = new HttpClient();
            _clientCustomers.BaseAddress = new System.Uri(baseUrlCustomers);
            _clientCustomers.DefaultRequestHeaders.Clear();
            _clientCustomers.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientsubscribers
            _clientsubscribers = new HttpClient();
            string baseUrlSubscribers = "http://d3c70764.ngrok.io/";
            _clientsubscribers = new HttpClient();
            _clientsubscribers.BaseAddress = new System.Uri(baseUrlSubscribers);
            _clientsubscribers.DefaultRequestHeaders.Clear();
            _clientsubscribers.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion
        }

        #region Fields and Properties

        HttpClient _clientRegistration;
        HttpClient _clientCapexOpex;
        HttpClient _clientInvestorProfit;
        HttpClient _clientCustomers;
        HttpClient _clientsubscribers;


        #endregion

        #region Methods

        #region Read from API Gateway
        public async Task<List<CustomerReportDTO>> GetCustomerReportDTOAsync()
        {

            var requestUri = $"/customers";
            var response = await _clientRegistration.GetAsync(requestUri);
            List<CustomerReportDTO> registrationItem = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    registrationItem = await response.Content.ReadAsAsync<List<CustomerReportDTO>>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return registrationItem;
        }

        public async Task<List<SubscriberReportDTO>> GetSubscriberReportDTOAsync()
        {

            var requestUri = $"/subscribers";
            var response = await _clientsubscribers.GetAsync(requestUri);
            List<SubscriberReportDTO> subscribersItems = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    subscribersItems = await response.Content.ReadAsAsync<List<SubscriberReportDTO>>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return subscribersItems;
        }

        public async Task<InvestorDTO> GetInvestorDTOAsync()
        {

            var requestUri = $"/investor";
            var response = await _clientRegistration.GetAsync(requestUri);
            InvestorDTO investorDTO = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    investorDTO = await response.Content.ReadAsAsync<InvestorDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return investorDTO;
        }

        public async Task<InvestorProfitDTO> GetInvestorProfitDTOAsync()
        {

            var requestUri = $"/investorprolile";
            var response = await _clientsubscribers.GetAsync(requestUri);
            InvestorProfitDTO InvestorProfititems = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    InvestorProfititems = await response.Content.ReadAsAsync<InvestorProfitDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return InvestorProfititems;
        }

        #endregion

        #region Save to API Gateway


        #endregion

        #endregion
    }
}
