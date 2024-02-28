using DryvaClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DryvaClient.Views.Forms
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            ViewModel = new RegistrationViewModel(Navigation);
            BindingContext = ViewModel;
        }

        private RegistrationViewModel viewModel;

        public RegistrationViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Application.Current.Properties[viewModel.ToString()] = ViewModel;
        }
    }
}