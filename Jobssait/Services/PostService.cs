using Jobssait;
using Jobssait.Models;
using Jobssait.Models.DTO;
using Microsoft.EntityFrameworkCore;
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

        public List<PostDTO> GetAll()
        {

            return dbContext.Posts
                .Include(p => p.User)
                .Select(p => ToDto(p))
                .ToList();
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
        public void Preview(int id)
        {
            Post dbpost = GetById(id);
           // dbContext.Posts.Remove(dbpost);
           // dbContext.SaveChanges();
            //return post;
        }

        public Post GetById(int id)
        {
            return dbContext.Posts.FirstOrDefault(x => x.Id == id);
        }
        private static PostDTO ToDto(Post p)
        {
            PostDTO product = new PostDTO();

            product.Id = p.Id;
            product.Name = p.Name;
            product.Content = p.Content;
               product.CreatedBy = $"{p.User.Userusername}";
            product.UserEmail = p.User.Email;

            return product;
        }
    }
}