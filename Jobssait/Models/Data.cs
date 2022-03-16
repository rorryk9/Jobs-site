using Jobssait.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait
{
    public class Data : IData
    {
        public List<Post> Posts { get; set; }

        public Data()
        {
            this.Posts = new List<Post>()
            {
                new Post("Some Content"),
                new Post("More Content"),
                new Post("Another Content"),
            };
        }
    }
}