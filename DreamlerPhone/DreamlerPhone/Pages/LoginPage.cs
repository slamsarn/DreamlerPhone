using System;
using Xamarin.Forms;
using DreamlerPhone.ViewModels;
using System.Net.Http;
using DreamlerPhone.Pages;

namespace DreamlerPhone {
    public partial class LoginPage : ContentPage {

        public static Com Com { get; set; }

        private Entry   _ebxUsername, _ebxPassword;
        private Label   _lblFeedback;
        private Button  _btnOk;

        public LoginPage() {
            Com = new Com();
            BindingContext  = new LoginVM();
            _ebxUsername    = new Entry { VerticalOptions = LayoutOptions.Center, Placeholder = "Username" };
            _ebxPassword    = new Entry { VerticalOptions = LayoutOptions.Center, Placeholder = "Password", IsPassword = true };
            _lblFeedback    = new Label { VerticalOptions = LayoutOptions.Center, TextColor = Color.Aqua };
            _btnOk          = new Button { Text = "Login", IsEnabled = true };

            _btnOk.Clicked  += OnButtonClick;

            _ebxUsername.SetBinding( Entry.TextProperty, "UsernameText" );
            _ebxPassword.SetBinding( Entry.TextProperty, "PasswordText" );
            _lblFeedback.SetBinding( Label.TextProperty, "FeedbackText" );

            Content         = new StackLayout {                
                Padding = 20,
                VerticalOptions = LayoutOptions.Center,
                Children = { _ebxUsername, _ebxPassword, _btnOk, _lblFeedback }
            };
        }

        private async void OnButtonClick( object sender, EventArgs e ) {
            try {
                string usrname  = _ebxUsername.Text;
                string pssword  = _ebxPassword.Text;

                ( ( Button ) sender ).IsEnabled = false;
                ( ( Button ) sender ).Text = "Checking credentials...";

                var response    = await Com.Login(usrname,pssword);
                if ( response != null ) {
                    ( ( Button ) sender ).Text = "Logged in!";                    
                    _lblFeedback.Text =
                        $"Loading projects, please wait..."         + Environment.NewLine +
                        $"UserName:     {response.UserName}"        + Environment.NewLine +
                        $"DreamlerId:   {response.DreamlerIdentity}"+ Environment.NewLine +
                        $"MobileToken:  {response.MobileToken}"     + Environment.NewLine +
                        $"ImageId       {response.ProfileImageUrl}";

                    await Navigation.PushAsync( new BoardListPage(await Com.GetData()); //Change page when projects data has been loaded

                } else {
                    ( ( Button ) sender ).Text = "Login";
                    ( ( Button ) sender ).IsEnabled = true;
                    _lblFeedback.Text = "       Invalid email or password";
                }
            } catch ( HttpRequestException httpRequestEx ) {
                _lblFeedback.Text =  
                    $"          Network Error"                  +Environment.NewLine+
                    $"Message:          {httpRequestEx.Message}"+Environment.NewLine+
                    $"Source:           {httpRequestEx.Source}" +Environment.NewLine+
                    $"InnerException:   {httpRequestEx.InnerException}";
            } catch ( Exception ex ) {
                _lblFeedback.Text =
                    $"          Internal Error"             +Environment.NewLine+
                    $"Message:          {ex.Message}"       +Environment.NewLine+
                    $"Source:           {ex.Source}"        +Environment.NewLine+
                    $"StackTrace:       {ex.StackTrace}"    +Environment.NewLine+
                    $"InnerException:   {ex.InnerException}"+Environment.NewLine+
                    $"Exception:        {ex}";
            }
        }
    }
}