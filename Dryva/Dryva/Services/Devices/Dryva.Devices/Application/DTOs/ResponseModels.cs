using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.DTOs
{
    /// <summary>
    /// Represents an IResponseModel interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponseModel<T> where T : class
    {
        /// <summary>
        /// Gets or sets a value indicating whether the caller was authenticated.
        /// </summary>
        /// <value><c>true</c> if authenticated; otherwise, <c>false</c>.</value>
        bool Authenticated { get; set; }
        /// <summary>
        /// Gets or sets the response messages.
        /// </summary>
        /// <value>The messages.</value>
        List<string> Messages { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the request was successful.
        /// </summary>
        /// <value><c>true</c> if successful; otherwise, <c>false</c>.</value>
        bool Successful { get; set; }
        /// <summary>
        /// Gets or sets the JWT token.
        /// </summary>
        /// <value>The token.</value>
        string Token { get; set; }

        /// <summary>
        /// Gets or sets the target instance for the response.
        /// </summary>
        /// <value>The instance.</value>
        T Instance { get; set; }
    }

    public abstract class ResponseModel<T> : BaseDTO, IResponseModel<T> where T : class
    {
        public ResponseModel()
        {
            Authenticated = false;
            Successful = true;
            Messages = new List<string>();
        }

        public bool Authenticated { get; set; }
        public List<string> Messages { get; set; }
        public bool Successful { get; set; }
        public string Token { get; set; }
        public T Instance { get; set; }
    }
}
