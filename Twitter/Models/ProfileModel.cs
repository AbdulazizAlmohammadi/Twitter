using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ProfileModel
    {
        [Key]
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string ProfilePicture { get; set; }
        [MaxLength(160)]
        public string Bio { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalFollowing { get; set; }
        public int NumberOfTweets { get; set; }
        public DateTime DateOfJoin { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }

    }
}
