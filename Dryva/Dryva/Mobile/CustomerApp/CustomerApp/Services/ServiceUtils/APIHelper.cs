using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services.ServiceUtils
{
    internal class APIHelper
    {
        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            string baseUrl = "http://caf10eba.ngrok.io";
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            return client;
        }
        private static async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await GetHttpClient().GetAsync(url);
        }

        private static async Task<HttpResponseMessage> PostAsync(object requestObject, string url)
        {
            return await GetHttpClient().PostAsJsonAsync(url, requestObject).ConfigureAwait(false);
        }
        private static async Task<HttpResponseMessage> PostAsync<T>(T requestObject, string url)
        {
            return await GetHttpClient().PostAsJsonAsync<T>(url, requestObject).ConfigureAwait(false);
        }
        private static async Task<HttpResponseMessage> PutAsync(object requestObject, string url, IEnumerable<string> ids)
        {
            var cli = GetHttpClient();
            if (ids != null)
            {
                foreach (var id in ids)
                {
                    cli.DefaultRequestHeaders.Add("ids", id);
                }
            }
            return await cli.PutAsJsonAsync(url, requestObject).ConfigureAwait(false);
        }
        private static async Task<HttpResponseMessage> DeleteAsync(string url, IEnumerable<string> ids = null)
        {
            var cli = GetHttpClient();
            if (ids != null)
            {
                foreach (var id in ids)
                {
                    cli.DefaultRequestHeaders.Add("ids", id);
                }
            }
            return await cli.DeleteAsync(url);
        }
        private static string GetUrl(string controllerName, string endPoint = null)
        {
            if (string.IsNullOrEmpty(endPoint))
                return controllerName;
            else
                return $"{controllerName}/{endPoint}";
        }
        internal static async Task<EnvelopeData<T>> GetData<T>(string controllerName, string endPoint = null)
        {
            string url = GetUrl(controllerName, endPoint);
            var envelope = new Envelope<T>();
            try
            {
                using (HttpResponseMessage response = await APIHelper.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsAsync<T>();
                        return envelope.ReportSuccess(result);
                    }
                    else
                    {
                        return envelope.ReportError(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                envelope.ReportError(ex.Message);
            }
            return envelope.ReportError(null);
        }

        internal static async Task<EnvelopeData<T>> InsertData<T>(T model, string controllerName, string endPoint = null)
        {
            string url = GetUrl(controllerName, endPoint);
            var envelope = new Envelope<T>();
            using (HttpResponseMessage response = await APIHelper.PostAsync<T>(model, url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<T>();
                    return envelope.ReportSuccess(result);
                }
                else
                {
                    return envelope.ReportError(response.ReasonPhrase);
                }
            }
        }
        public static async Task<EnvelopeData<T>> UpdateData<T>(object model, string controllerName, string endpoint = null, IEnumerable<string> ids = null)
        {
            var envelope = new Envelope<T>();
            string url = $"{controllerName}/{endpoint}";
            using (HttpResponseMessage response = await APIHelper.PutAsync(model, url, ids))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<T>();
                    return envelope.ReportSuccess(result);
                }
                else
                {
                    return envelope.ReportError(response.ReasonPhrase);
                }
            }
        }
        internal static async Task<EnvelopeData<T>> UpdateField<T>(object model, string controllerName, string endPoint = null)
        {
            var envelope = new Envelope<T>();
            string url = GetUrl(controllerName, endPoint);
            using (HttpResponseMessage response = await APIHelper.PutAsync(model, url, null))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<T>();
                    return envelope.ReportSuccess(result);
                }
                else
                {
                    return envelope.ReportError(response.ReasonPhrase);
                }
            }
        }

        internal static async Task<EnvelopeData> DeleteData(string controllerName, string endPoint = null, IEnumerable<string> ids = null)
        {
            string url = GetUrl(controllerName, endPoint);
            using (HttpResponseMessage response = await APIHelper.DeleteAsync(url, ids))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<object>();
                    return Envelope.ReportSuccess();
                }
                else
                {
                    return Envelope.ReportError(response.ReasonPhrase);
                }
            }
        }


    }
}
