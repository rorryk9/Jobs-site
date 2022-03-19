using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobssait.Models
{
    public class Post
    {
     /*   private static int id = 0;

        private string content;

        public Post(string content)
        {
            Id = ++id;
            Content = content;
        }
     */

        public int Id { get; set; }

        public string Name { get; set; }


        /*     public string Content
             {
                 get { return content; }
                 set
                 {
                     if (string.IsNullOrEmpty(value))
                     {
                         throw new ArgumentException("Content cannot be null or empty!");
                     }

                     content = value;
                 }
             }*/

        public string Content { get; set; }

        [ForeignKey("User")]
        public int UseerId { get; set; }
        public User User { get; set; }
    }
}