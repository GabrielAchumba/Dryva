using CusApp.DTOs.Customer;
using CusApp.DTOs.Device;
using CusApp.DTOs.Driver;
using CusApp.DTOs.Financial;
using CusApp.DTOs.MapsDTO;
using CusApp.Helpers;
using CusApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CusApp.Data
{
    public class RestService : IRestService
    {
        HttpClient _clientRegistration;
        HttpClient _clientWallet;
        HttpClient _clientMaps;
        HttpClient _clientDeviceTrail;
        HttpClient _clientVehicle;
        HttpClient _clientSubscription;

        public List<WalletItem> walletItems { get; private set; }
        public RegistrationDTO registrationItem { get; private set; }

        public MapAxisDTO mapAxisDTO { get; private set; }

        public DeviceTrailDTO deviceTrailDTO { get; private set; }

        public VehicleDTO vehicleDTO { get;private set; }

        public SubscriptionDTO subscriptionDTO { get; set; }

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

            #region _clientWallet
            _clientWallet = new HttpClient();
            string baseUrlWallet = "http://d3c70764.ngrok.io/";
            _clientWallet = new HttpClient();
            _clientWallet.BaseAddress = new System.Uri(baseUrlWallet);
            _clientWallet.DefaultRequestHeaders.Clear();
            _clientWallet.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientMaps
            _clientMaps = new HttpClient();
            string baseUrlMaps = "http://d3c70764.ngrok.io/";
            _clientMaps = new HttpClient();
            _clientMaps.BaseAddress = new System.Uri(baseUrlMaps);
            _clientMaps.DefaultRequestHeaders.Clear();
            _clientMaps.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientDeviceTrail
            _clientDeviceTrail = new HttpClient();
            string baseUrlDeviceTrail = "http://d3c70764.ngrok.io/";
            _clientDeviceTrail = new HttpClient();
            _clientDeviceTrail.BaseAddress = new System.Uri(baseUrlDeviceTrail);
            _clientDeviceTrail.DefaultRequestHeaders.Clear();
            _clientDeviceTrail.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion

            #region _clientVehicle

            _clientVehicle = new HttpClient();
            string baseUrlVehicle = "http://d3c70764.ngrok.io/";
            _clientVehicle = new HttpClient();
            _clientVehicle.BaseAddress = new System.Uri(baseUrlVehicle);
            _clientVehicle.DefaultRequestHeaders.Clear();
            _clientVehicle.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            #endregion

            #region _clientVehicle

            _clientSubscription = new HttpClient();
            string baseUrlSubscription = "http://d3c70764.ngrok.io/";
            _clientSubscription = new HttpClient();
            _clientSubscription.BaseAddress = new System.Uri(baseUrlSubscription);
            _clientSubscription.DefaultRequestHeaders.Clear();
            _clientSubscription.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            #endregion
        }

        #region Read from API Gateway

        public async Task<List<WalletItem>> RefreshWalletItemsAsync()
        {
            walletItems = null;

            var uri = "api/wallet";
            try
            {
                walletItems = new List<WalletItem>();
                var response = await _clientWallet.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    walletItems = JsonConvert.DeserializeObject<List<WalletItem>>(content);
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return walletItems;
        }
        public async Task<RegistrationDTO> RefreshRegistrationDTOAsync()
        {

            var requestUri = $"api/customers";
            var response = await _clientRegistration.GetAsync(requestUri);
            registrationItem = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    registrationItem = await response.Content.ReadAsAsync<RegistrationDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return registrationItem;
        }
        public async Task<MapAxisDTO> RefreshMapAxisDTOAsync()
        {

            var requestUri = $"api/maps";
            var response = await _clientMaps.GetAsync(requestUri);
            mapAxisDTO = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    mapAxisDTO = await response.Content.ReadAsAsync<MapAxisDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return mapAxisDTO;
        }

        public async Task<DeviceTrailDTO> RefreshDeviceTrailDTOAsync()
        {

            var requestUri = $"api/devicetrail";
            var response = await _clientDeviceTrail.GetAsync(requestUri);
            deviceTrailDTO = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    deviceTrailDTO = await response.Content.ReadAsAsync<DeviceTrailDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return deviceTrailDTO;
        }

        public async Task<VehicleDTO> RefreshVehicleDTOAsync()
        {

            var requestUri = $"api/devicetrail";
            var response = await _clientVehicle.GetAsync(requestUri);
            vehicleDTO = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    vehicleDTO = await response.Content.ReadAsAsync<VehicleDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return vehicleDTO;
        }

        public async Task<SubscriptionDTO> RefreshSubscriptionDTOAsync()
        {

            var requestUri = $"api/subscription";
            var response = await _clientSubscription.GetAsync(requestUri);
            subscriptionDTO = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    subscriptionDTO = await response.Content.ReadAsAsync<SubscriptionDTO>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return subscriptionDTO;
        }

        public async Task<List<SubscriptionDTO>> RefreshSubscriptionDTOListAsync()
        {
            var requestUri = $"api/subscriptionList";
            var response = await _clientSubscription.GetAsync(requestUri);
            List<SubscriptionDTO> subscriptionDTOList = null;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    subscriptionDTOList = await response.Content.ReadAsAsync<List<SubscriptionDTO>>();
                }
            }
            catch (Exception)
            {

                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return subscriptionDTOList;
        }

        #endregion

        #region Save to API Gateway

        public async Task SaveWalletItemsAsync(WalletItem item)
        {
            var uri = "api/wallet";

            try
            {
                HttpResponseMessage response = await _clientWallet.PostAsJsonAsync(uri, item);

                if (response.IsSuccessStatusCode)
                {
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveRegistrationDTOAsync(RegistrationDTO item)
        {
            var uri = "api/customers";

            try
            {
                HttpResponseMessage response = await _clientRegistration.PostAsJsonAsync(uri, item);

                if (response.IsSuccessStatusCode)
                {
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveMapAxisDTOAsync(MapAxisDTO item)
        {
            var uri = "api/maps";

            try
            {
                HttpResponseMessage response = await _clientMaps.PostAsJsonAsync(uri, item);

                if (response.IsSuccessStatusCode)
                {
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveDeviceTrailDTOAsync(DeviceTrailDTO item)
        {
            var uri = "api/devicetrail";

            try
            {
                HttpResponseMessage response = await _clientDeviceTrail.PostAsJsonAsync(uri, item);

                if (response.IsSuccessStatusCode)
                {
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveSubscriptionDTOAsync(SubscriptionDTO item)
        {
            var uri = "api/subscription";

            try
            {
                HttpResponseMessage response = await _clientDeviceTrail.PostAsJsonAsync(uri, item);

                if (response.IsSuccessStatusCode)
                {
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SaveShareUnitDTOListAsync(List<ShareUnitDTO> items)
        {
            var uri = "api/shareunit";

            try
            {
                HttpResponseMessage response = await _clientDeviceTrail.PostAsJsonAsync(uri, items);

                if (response.IsSuccessStatusCode)
                {
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

       



        #endregion


    }
}
