using Jobssait;
using Jobssait.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Services
{
    public class PostService : IPostService
    {
        private IData data;

        public PostService(IData data)
        {
            this.data = data;
        }

        public List<Post> GetAll()
        {
            return data.Posts;
        }

        public Post Create(string content)
        {
            Post post = new Post(content);
            data.Posts.Add(post);

            return post;
        }

        public Post Edit(int id, string content)
        {
            Post post = GetById(id);
            post.Content = content;

            return post;
        }
        public Post Delete(int id)
        {
            Post post = GetById(id);
            data.Posts.Remove(post);

            return post;
        }

        public Post GetById(int id)
        {
            return data.Posts.FirstOrDefault(p => p.Id == id);
        }
    }
}