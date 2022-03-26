using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Models
{
    public class Applyence 
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public int UseerId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PosstId { get; set; }
        public Post Post { get; set; }
        

    }
}
