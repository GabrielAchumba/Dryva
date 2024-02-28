using CusApp.Enum;
using CusApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CusApp.Controls.Alert
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertControl : ContentPage
    {
        public ICommand ButtonCommand { get; set; }
        public string ButtonText { get { return this._btnTypeEnum.ToString(); } }
        public string MsgTitle { get; private set; }
        public string Message { get; private set; }
        public string IconName { get; private set; }
        private ButtonTypeEnum _btnTypeEnum;


        Dictionary<ButtonTypeEnum, Type> _btnType_Type_Mapping = new Dictionary<ButtonTypeEnum, Type>();
        public AlertControl(ButtonTypeEnum btnTypeEnum, IconTypeEnum iconType, string pageTitle, string msgtitle, params string[] msgs)
        {
            InitializeComponent();

            this.Title = pageTitle;
            this.Initialize(btnTypeEnum, iconType, msgtitle, msgs);
            this.ButtonCommand = new Command(this.ButtionAction);
            this.BindingContext = this;
        }
        private void Initialize(ButtonTypeEnum btnTypeEnum, IconTypeEnum iconType, string msgtitle, params string[] msgs)
        {
            this._btnTypeEnum = btnTypeEnum;
            this.MsgTitle = msgtitle;
            if (msgs != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in msgs)
                {
                    builder.Append("\n");
                    builder.Append(item);
                }
                this.Message = builder.ToString();
            }

            this.IconName = $"{iconType.ToString().ToLower()}.png";


            this._btnType_Type_Mapping.Add(ButtonTypeEnum.Home, typeof(LoginRegisterPage));
            this._btnType_Type_Mapping.Add(ButtonTypeEnum.Login, typeof(MainPage));
        }

        private async void ButtionAction()
        {
            await Navigation.PopModalAsync();
            if (this._btnType_Type_Mapping.ContainsKey(this._btnTypeEnum))
            {
                var _page = Activator.CreateInstance(this._btnType_Type_Mapping[this._btnTypeEnum]) as ContentPage;
                Application.Current.MainPage = new NavigationPage(_page);
                //await Navigation.PushAsync(_page);
            }
        }
    }
}