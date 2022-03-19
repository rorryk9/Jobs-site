using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobssait.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public int UseerId { get; set; }
        public User User { get; set; }
    }
}