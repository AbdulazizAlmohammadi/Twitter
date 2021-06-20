using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class TweetModel
    {
        [Key]
        public int TweetId { get; set; }
        [MaxLength(280)]
        public string TweetContent { get; set; }
        public string  TweetDate { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }

    }
}
