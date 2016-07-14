using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamlerPhone.ViewModels {
    public class LoginVM : INotifyPropertyChanged {
        private string  _username   = "glenn@zayas.se";
        private string  _password   = "glenn";
        private string  _fdbkMsg    = "";

        public string UsernameText {
            get { return _username; }
            set {
                if ( _username == value ) return;
                _username = value;
                OnPropertyChanged( "UsernameText" );
            }
        }
        public string PasswordText {
            get { return _password; }
            set {
                if ( _password == value ) return;
                _password = value;
                OnPropertyChanged( "PasswordText" );
            }
        }

        public string FeedbackText {
            get { return _fdbkMsg; }
            set {
                if ( _fdbkMsg == value ) return;
                _fdbkMsg = value;
                OnPropertyChanged( "FeedbackText" );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string propertyName ) {
            if ( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}
