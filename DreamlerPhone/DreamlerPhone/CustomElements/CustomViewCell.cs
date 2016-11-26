using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DreamlerPhone.CustomElements {
    public class CustomViewCell : ViewCell {
        public CustomViewCell() {
            var title = new Label();
            title.SetBinding( Label.TextProperty, "BoardTitleText" );
            var boardImg = new Image();
            boardImg.SetBinding( Image.SourceProperty, "ProjectImageSource" );            
        }
    }
}
