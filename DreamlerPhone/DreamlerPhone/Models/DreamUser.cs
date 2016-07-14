using System;

namespace DreamlerPhone.Models {
    public class DreamUser {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public DateTime CreationDate { get; set; }
        public string LoginToken { get; set; }
        public string PhoneNumber { get; set; }

        public string MobileToken { get; set; }
        public string Roles { get; set; }
        public bool HasProfileImage { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime Deleted { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public DateTime FailedPasswordAttemptWindowStart { get; set; }
        public long ImageId { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public bool HasValidSubscription { get; set; }
        public string DreamlerIdentity { get; set; }
    }
}
