using Jobssait.Models;
using System.Collections.Generic;

namespace Jobssait
{
    public interface IData
    {
        List<Post> Posts { get; set; }
    }
}