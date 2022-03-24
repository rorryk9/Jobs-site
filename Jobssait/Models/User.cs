using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Models
{
    public class User : IdentityUser<int>
    {
        public string Userusername { get; set; }

        
    }
}
