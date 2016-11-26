using System;
using System.Net;
using System.Net.Http;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace DreamlerPhone.Droid {
    [Activity( Label = "DreamlerPhone", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity /*Activity*/ {
        
        public static Com Com { get; set; }
        private static TextView txtText;
        
        protected override void OnCreate( Bundle bundle ) {

            ServicePointManager.ServerCertificateValidationCallback += ( sender, cert, chain, sslPolicyErrors ) => true;

            base.OnCreate( bundle );

            global::Xamarin.Forms.Forms.Init( this, bundle );

            LoadApplication( new App() );
            #region XamarinAndroidImpl
            //Comment out LoadApplication above
            //Uncomment ButtonOnClick below

            //Com = new DreamlerPhone.Com();

            //SetContentView( Resource.Layout.LoginPage );

            //var btn = FindViewById<Button>( Resource.Id.btnLogin );

            //btn.Click += ButtonOnClick;

            //txtText = FindViewById<TextView>( Resource.Id.txtTest );

            //global::Xamarin.Forms.Forms.Init( this, bundle );


            //LoadApplication( new App() );
            #endregion
        }
        //private async void ButtonOnClick( object sender, EventArgs e ) {
        //    try {
        //        var userName = FindViewById<EditText>(Resource.Id.tbxEmail).Text;
        //        var password = FindViewById<EditText>(Resource.Id.tbxPassword).Text;
        //        ( ( Button ) sender ).Enabled = false;
        //        ( ( Button ) sender ).Text = "Logging in...";
        //        var result = await Com.Login(userName, password);
        //        if ( result != null ) {
        //            txtText.Text = result.LoginToken + result.DreamlerIdentity;
        //            //var intent = new Intent(this, typeof());
        //        } else {
        //            //invalid email pass
        //            txtText.Text = "Invalid username or password";
        //            ( ( Button ) sender ).Enabled = true;
        //            ( ( Button ) sender ).Text = Resources.GetString( Resource.String.btnLogin );
        //        }
        //    } catch ( HttpRequestException httpRequestEx ) {
        //        txtText.Text = httpRequestEx.ToString();
        //    } catch ( Exception ex ) {
        //        txtText.Text = ex.ToString();
        //    }
        //}     
    }
}

