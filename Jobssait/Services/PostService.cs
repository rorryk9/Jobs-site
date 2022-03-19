using Jobssait;
using Jobssait.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobssait.Services
{
    public class PostService 
    {
       
        private UserDBContext dbContext;

        public PostService(UserDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Post> GetAll()
        {
            return dbContext.Posts.ToList();
        }

        public Post Create(Post post,User user)
        {
            post.User = user;

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

            return post;
        }
       

        public void Edit(Post post)
        {
            Post dbpost = GetById(post.Id);
            dbpost.Content = post.Content;
            dbContext.SaveChanges();
            //  return post;
        }
        public void Delete(int id)
        {
            Post dbpost = GetById(id);
            dbContext.Posts.Remove(dbpost);
            dbContext.SaveChanges();
            //return post;
        }

        public Post GetById(int id)
        {
            return dbContext.Posts.FirstOrDefault(x => x.Id == id);
        }
    }
}