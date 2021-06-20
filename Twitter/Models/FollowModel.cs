using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class FollowModel
    {
        
        public int userId { get; set; }
        public UserModel user { get; set; }
        public int followerId { get; set; }
        public UserModel follower { get; set; }

    }
}
