﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Models.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public string UserEmail { get; set; }
    }
}
