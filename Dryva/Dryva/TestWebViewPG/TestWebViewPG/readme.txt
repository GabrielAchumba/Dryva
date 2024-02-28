1. Create Xamrarin Forms project

2. In the Xaml page of interest add "Make Payment" button. Example below:

<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="WebViewPG.Forms.Test.MainPage">

    <StackLayout>
        <!-- Place new controls here -->
        <Label Text="Welcome to Xamarin.Forms!" 
           HorizontalOptions="Center"
           VerticalOptions="CenterAndExpand" />

        <Button x:Name="btnMakePayment" Text="Make Payment" Clicked="btnMakePayment_Clicked"></Button>
    </StackLayout>

</ContentPage>

3. On the button click event add the following codes to initiate PayStack payment.

var customer = new
{
    Amount = 2500,
    Currency = "NGN",
    Email = "wizzyno@gmail.com",
    FirstName = "Eniefiok",
    LastName = "Eniang",
    PhoneNumber = "08069328151",
    Plan = "Monthly"
};
var extras = new Dictionary<string, object>
{
    { PGExtra.ExtraCustomer, customer }
};
var launcher = DependencyService.Get<IActivityLauncher>();
launcher.SetCallback((args) =>
{
    // To receive success or failure callbacks
}).StartPayStackActivity(extras);

