using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DreamlerPhone.ViewModels {
    public class BoardListVM : INotifyPropertyChanged {
        private string      _projName;
        private ImageSource _imgSrc;
        private Image       _img;

        public string ProjectNameText {
            get { return _projName; }
        set {
                if ( _projName == value ) return;
                _projName = value;
                OnPropertyChanged( "ProjectNameText" );
            }
        }
        public ImageSource ProjectImageSource {
            get { return _imgSrc; }
            set {
                if ( _imgSrc == value ) return;
                _imgSrc = value;
                OnPropertyChanged( "ProjImageSource" );
            }
        }
        public Image ProjectImage {
            get { return _img; }
            set {
                if ( _img == value ) return;
                _img = value;
                OnPropertyChanged( "ProjectImage" );
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged (string propName) {
            if (propName != null) {
                PropertyChanged( this, new PropertyChangedEventArgs( propName ) );
            }
        }
    }
}
