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

        public void Create(Post post, User user)
        {
            post.User = user;

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

        }


        public void Edit(Post post)
        {
            Post dbpost = GetById(post.Id);
            dbpost.Content = post.Content;
            dbpost.Spaces = post.Spaces;
            dbContext.SaveChanges();

        }
        public void Delete(int id)
        {
            Post dbpost = GetById(id);
            dbContext.Posts.Remove(dbpost);
            dbContext.SaveChanges();
        }
        public void Aply(int id)
        {
            Post dbpost = GetById(id);
            dbpost.Spaces --;
             dbContext.SaveChanges();
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
            product.Spaces = p.Spaces;
            product.CreatedBy = $"{p.User.Userusername}";
            product.UserEmail = p.User.Email;

            return product;
        }
    }
}