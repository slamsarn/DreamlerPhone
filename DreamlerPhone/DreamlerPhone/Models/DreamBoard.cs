using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DreamlerPhone.Models {
    public class DreamBoard {
        public long Id { get; set; }
        public long OwnerUserId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? LastEdit { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Endpoint { get; set; }
        public int HistoryCount { get; set; }
        public bool IsRunning { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasImage { get; set; }
        public IEnumerable<long> AllowedUsers { get; set; }
        public int UserCount { get; set; }
        public int CommentCount { get; set; }
        public bool IsFav { get; set; }
        public long ImageId { get; set; }
        public string ImageUrl { get; set; }
        public Image Image { get; set; }
    }
}
