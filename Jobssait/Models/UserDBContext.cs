using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Models
{
    public class UserDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
       
        public UserDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
