using System.ComponentModel.DataAnnotations;

namespace WebbDejt2.Models
{
    public class Friend
    {
        [Key]
        public string keyId { get; set; }
        
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Receiver { get; set; }

        public bool FriendAccepted { get; set; }

        public Friend() { }

        public Friend(ApplicationUser From, ApplicationUser To)
        {
            this.FriendAccepted = false;
            this.Sender = From;
            this.Receiver = To;
            this.keyId = From.Id + To.Id;
        }
    }
}