﻿using System;
using Xamarin.Forms;
using DreamlerPhone.ViewModels;
using System.Net.Http;

namespace DreamlerPhone {
    public partial class LoginPage : ContentPage {

        public static Com Com { get; set; }

        private Entry   _ebxUsername;
        private Entry   _ebxPassword;
        private Label   _lblFeedback;
        private Button  _btnLogin;

        public LoginPage() {
            //InitializeComponent();
            BindingContext  = new LoginVM();
            _ebxUsername    = new Entry { Placeholder = "Username", VerticalOptions = LayoutOptions.Center };
            _ebxPassword    = new Entry { Placeholder = "Password", VerticalOptions = LayoutOptions.Center, IsPassword = true };
            _lblFeedback    = new Label { TextColor = Color.Aqua, VerticalOptions = LayoutOptions.Center };
            _btnLogin       = new Button { Text = "Login", IsEnabled = true };

            _btnLogin.Clicked += OnButtonClick;

            _ebxUsername.SetBinding( Entry.TextProperty, "UsernameText" );
            _ebxPassword.SetBinding( Entry.TextProperty, "PasswordText" );
            _lblFeedback.SetBinding( Label.TextProperty, "FeedbackText" );

            Content         = new StackLayout {
                Padding     = 20,
                VerticalOptions = LayoutOptions.Center,
                Children    = { _ebxUsername, _ebxPassword, _btnLogin, _lblFeedback }
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
                    ( ( Button ) sender ).Text = "Logged in";
                    _lblFeedback.Text =
                        $"UserName:     {response.UserName}" + Environment.NewLine +
                        $"DreamlerId:   {response.DreamlerIdentity}" + Environment.NewLine +
                        $"MobileToken:  {response.MobileToken}";
                } else {
                    ( ( Button ) sender ).Text = "Login";
                    ( ( Button ) sender ).IsEnabled = true;
                    _lblFeedback.Text = "Invalid email or password";
                }
            } catch ( HttpRequestException httpRequestEx ) {
                _lblFeedback.Text = httpRequestEx.InnerException.ToString();
            } catch ( Exception ex ) {
                _lblFeedback.Text = ex.ToString();
            }
        }
    }
}
