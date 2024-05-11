using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Models
{
    public class Post
    {
        public const int max_title_length = 50;
        private Post(Guid id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Content { get; } = string.Empty;

        public static (Post Post, string Error) Create(Guid id, string title, string content)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(title) || title.Length > max_title_length)
            {
                error += string.Format("Title can`t be empty or must be leaser than {0}\n", max_title_length);
            }

            if (string.IsNullOrEmpty(content))
            {
                error += "Content can`t be empty";
            }

            var post = new Post(id, title, content);
            return (post, error);
        }
    }
}
