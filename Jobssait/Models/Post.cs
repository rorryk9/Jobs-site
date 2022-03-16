using System;

namespace Jobssait.Models
{
    public class Post
    {
        private static int id = 0;

        private string content;

        public Post(string content)
        {
            Id = ++id;
            Content = content;
        }

        public int Id { get; }

        public string Content
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
        }
    }
}