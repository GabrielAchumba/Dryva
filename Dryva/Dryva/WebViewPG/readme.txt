This is the test project for the WebView Payment Gateway for Android (WebViewPG.Droid).
It uses a WebView to handle Payment Gateways (PayStack for now).

To install use the following commands:
Package Manager:
Install-Package WebViewPG.Droid.Dryva -Version 1.0.0.1-alpha

.NET CLI
dotnet add package WebViewPG.Droid.Dryva --version 1.0.0.1-alpha

To use Package Manager UI, enable 'Pre Release' to find and install.

To customize the WebView, use the html template as a guide.

<!-- PAYSTACK TEMPLATE -->
<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>App</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/x-icon" href="favicon.ico">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    <!-- ADDITIONAL CSS -->
    <style type="text/css">

    </style>
</head>
<body>
    <!-- INSERT HTML CONTENT HERE-->

    <form class="form-inline">
        <div class="form-group">
            <button class="btn btn-primary" type="button" onclick="payWithPayStack()">{Enter Button Caption}</button>
        </div>
    </form>

    <script src="https://js.paystack.co/v1/inline.js"></script>
    <script type="text/javascript">{0}</script>
</body>
</html>


******* NOTE!!! ********
1. The button that invokes the payment MUST implement onclick with the call to the functions:
   PayStack:
   payWithPayStack()

   Other Payment Gateways would have their own function call.

2. The script tag: '<script type="text/javascript">{0}</script>' is required for the library
   to inject the execution script of the Payment Gateway and other interfaces.

