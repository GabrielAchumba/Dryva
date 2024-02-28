using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    /// <summary>
    /// Represents the RequestMetadataExtender class.
    /// Implements the <see cref="Dryva.PaymentGateways.PayStack.IPreparable" />
    /// </summary>
    /// <seealso cref="Dryva.PaymentGateways.PayStack.IPreparable" />
    public class RequestMetadataExtender : IPreparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestMetadataExtender"/> class.
        /// </summary>
        public RequestMetadataExtender()
        {
            CustomFields = new List<CustomField>();
            MetadataObject = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        [JsonIgnore]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the metadata object.
        /// </summary>
        /// <value>The metadata object.</value>
        [JsonIgnore]
        public Dictionary<string, object> MetadataObject { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        public string Metadata { get; set; }

        /// <summary>
        /// Prepares this instance.
        /// </summary>
        public virtual void Prepare()
        {
            MetadataObject["custom_fields"] = CustomFields.ToArray();
            Metadata = JsonConvert.SerializeObject(MetadataObject, PayStackApi.SerializerSettings);
        }
    }

    /// <summary>
    /// Represents the Metadata class.
    /// Implements the <see cref="System.Collections.Generic.Dictionary{System.String, System.Object}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, System.Object}" />
    public class Metadata : Dictionary<string, object>
    {
        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>The custom fields.</value>
        [JsonProperty("custom_fields")]
        public IList<CustomField> CustomFields { get; set; }
    }

    /// <summary>
    /// Represents the CustomField class.
    /// </summary>
    public class CustomField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomField"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="variableName">Te name of the variable.</param>
        /// <param name="value">The value.</param>
        public CustomField(string displayName, string variableName, string value)
        {
            DisplayName = displayName;
            VariableName = variableName;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the variable.
        /// </summary>
        /// <value>The name of the variable.</value>
        [JsonProperty("variable_name")]
        public string VariableName { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        /// <summary>
        /// Creates a custom field from the specified display name, variable name and value.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="value">The value.</param>
        /// <returns>CustomField.</returns>
        public static CustomField From(string displayName, string variableName, string value)
            => new CustomField(displayName, variableName, value);
    }
}