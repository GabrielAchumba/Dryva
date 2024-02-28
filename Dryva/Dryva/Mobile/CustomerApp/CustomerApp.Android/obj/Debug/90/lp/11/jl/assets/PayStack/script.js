
function payWithPayStack() {
    var handler = PaystackPop.setup({
        key: '{0}',
        email: '{1}',
        amount: '{2}',
        currency: '{3}',
        ref: '{4}',
        firstname: '{5}',
        lastname: '{6}',
        // label: "Optional string that replaces customer email"
        metadata: {
            custom_fields: [
                {
                    display_name: "Mobile Number",
                    variable_name: "mobile_number",
                    value: "{7}"
                }
            ]
        },
        callback: function (response) {
            try {
                PayStackBridge.Process(response.reference);
            } catch (err) {
                alert('Oops! Failed to complete transaction processing.');
            }
        },
        onClose: function () {
            PayStackBridge.Close();
        }
    });
    handler.openIframe();
}
