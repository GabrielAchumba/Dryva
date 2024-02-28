using System.Linq;
using System.Web;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the IPreparable interface.
    /// </summary>
    public interface IPreparable
    {
        /// <summary>
        /// Prepares this instance.
        /// </summary>
        void Prepare();
    }

    /// <summary>
    /// Represents the Extension class.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Converts the request to query string.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        public static string ToQueryString(this object request)
        {
            var properties = from p in request.GetType().GetProperties()
                let v = p.GetValue(request, null)
                where v != null
                select p.Name + "=" + HttpUtility.UrlEncode(v.ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}