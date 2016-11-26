using DreamlerPhone.CustomElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DreamlerPhone.Models;

namespace DreamlerPhone.Pages {
    public class BoardListPage : ContentPage {
        private List<DreamBoard> myDreamBoards = new List<DreamBoard>();

        public DreamUser User { get; set; }

        public BoardListPage( List<DreamBoard> authedUsersDreamBoards ) {
            myDreamBoards = authedUsersDreamBoards;
            var img = new Image {Source = new UriImageSource { Uri = new Uri(myDreamBoards.FirstOrDefault()?.ImageUrl) } }; 
        }
    }
}

