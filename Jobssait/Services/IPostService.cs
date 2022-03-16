using Jobssait.Models;
using System.Collections.Generic;

namespace Jobssait.Services
{
    public interface IPostService
    {
        Post Create(string content);
        Post Delete(int id);
        Post Edit(int id, string content);
        List<Post> GetAll();
        Post GetById(int id);
    }
}