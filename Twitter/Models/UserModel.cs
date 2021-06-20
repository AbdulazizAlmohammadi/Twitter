using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class UserModel
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string userEmail { get; set; }
        [Required]
        public string password { get; set; }

        public ProfileModel Profile { get; set; }

        public ICollection<UserModel> Followers { get; set; }
        public List<FollowModel> UserFollowers { get; set; }
        public ICollection<UserModel> Following { get; set; }
        public List<FollowModel> UserFollowing { get; set; }

    }
}
