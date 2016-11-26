using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamlerPhone.Models;
using Xamarin.Forms;
using DreamlerPhone;

namespace DreamlerPhone {
    public class App : Application {
        //public static Com Com { get; set; }
        public App() {
            MainPage = new LoginPage();

        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
