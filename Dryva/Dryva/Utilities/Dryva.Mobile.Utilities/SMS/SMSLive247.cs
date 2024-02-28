using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dryva.Utilities.SMS
{
    /// <summary>
    /// Represents an SMSLive247 Http API service.
    /// </summary>
    public class SMSLive247Service : ISMSLive247Service
    {
        private readonly string baseUrl = "http://www.smslive247.com/http/index.aspx";
        private Guid sessionId = Guid.Empty;

        /// <summary>
        /// Gets a value indicating whether the service is authenticated.
        /// </summary>
        /// <value><c>true</c> if the service is authenticated; otherwise, <c>false</c>.</value>
        public bool IsAuthenticated => sessionId != Guid.Empty;

        /// <summary>
        /// Authenticates the service with the SMS gateway using the supplied credentials.
        /// </summary>
        /// <param name="email">The SMS account email.</param>
        /// <param name="name">The sub-account name.</param>
        /// <param name="password">The sub-account password.</param>
        /// <returns>
        ///   <c>true</c> if authenticated, <c>false</c> otherwise.</returns>
        public bool Login(string email, string name, string password)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);
            
            request.AddParameter("cmd", "login");
            request.AddParameter("owneremail", email);
            request.AddParameter("subacct", name);
            request.AddParameter("subacctpwd", password);

            var result = client.Execute(request);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var id = Guid.Parse(result.Content.Substring(result.Content.IndexOf(':') + 1));
                sessionId = id;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sends an SMS message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender name.</param>
        /// <param name="sendTo">The receiver's phone number.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public int? SendMessage(string message, string sender, string sendTo)
        {
            return SendMessage(message, sender, sendTo, 0);
        }

        /// <summary>
        /// Sends an SMS message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="sender">The sender name.</param>
        /// <param name="sendTo">The receiver's phone number.</param>
        /// <param name="messageType">Type of the message (0 = Normal Message, 1 = Alert Message).</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public int? SendMessage(string message, string sender, string sendTo, int messageType)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);

            request.AddParameter("cmd", "sendmsg");
            request.AddParameter("sessionid", sessionId);
            request.AddParameter("message", message);
            request.AddParameter("sender", sender);
            request.AddParameter("sendto", sendTo);
            request.AddParameter("msgtype", messageType);

            var result = client.Execute(request);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var id = int.Parse(result.Content.Substring(result.Content.IndexOf(':') + 1));
                return id;
            }
            return null;
        }

        /// <summary>
        /// Queries the balance of SMS units left.
        /// </summary>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public int? QueryBalance()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.GET);

            request.AddParameter("cmd", "querybalance");
            request.AddParameter("sessionid", sessionId);

            var result = client.Execute(request);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var balance = int.Parse(result.Content.Substring(result.Content.IndexOf(':') + 1));
                return balance;
            }

            return null;
        }
    }
}
