using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CusApp.ViewModels
{
    public class LoginRegisterViewModel : ViewModelBase
    {
        public LoginRegisterViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.LoginCommand = new Command(async () => await LoginAction());
            this.RegistrationCommand = new Command(async () => await RegistrationAction());
            Description
               = "Mr. Sherlock Holmes, who was usually very late in " +
                   "the mornings, save upon those not infrequent " +
                   "occasions when he was up all night, was seated at " +
                   "the breakfast table. I stood upon the hearth-rug " +
                   "and picked up the stick which our visitor had left " +
                   "behind him the night before. It was a fine, thick " +
                   "piece of wood, bulbous-headed, of the sort which " +
                   "is known as a \u201CPenang lawyer";

        }

        #region Fields and Properties

        #region Commands

        public INavigation Navigation { get; set; }

        public ICommand LoginCommand { private set; get; }

        public ICommand RegistrationCommand { private set; get; }

        #endregion


        #region Description
        private string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        #endregion

        #endregion


        #region Methods

        #region LoginAction

        private async Task LoginAction()
        {
            await Navigation.PushAsync(new LoginPage());
        }
        #endregion

        #region RegistrationAction
        private async Task RegistrationAction()
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        #endregion

        public override string ToString()
        {
            return "LoginViewModel";
        }
        #endregion
    }
}
