using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the IHasRawResponse interface.
    /// </summary>
    public interface IHasRawResponse
    {
        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        /// <value>The raw json.</value>
        string RawJson { get; set; }
    }

    /// <summary>
    /// Represents the HasRawResponse class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.IHasRawResponse" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.IHasRawResponse" />
    public class HasRawResponse : IHasRawResponse
    {
        /// <summary>
        /// Gets or sets the raw json.
        /// </summary>
        /// <value>The raw json.</value>
        public string RawJson { get; set; }
    }
}