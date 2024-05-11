using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Models
{
    public class Topic
    {
        public const int max_name_lenght = 15;
        private Topic(Guid id, string name)
        {
            Id = id;
            Name = name;
            Posts = [];
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public List<Post> Posts { get; }

        public static (Topic Topic, string Error) Create(Guid id, string name)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > max_name_lenght)
            {
                error += string.Format("Name can`t be empty or must be leaser than {0}", max_name_lenght);
            }

            var topic = new Topic(id, name);
            return (topic, error);
        }

        public void AddPost(Post post)
        {
            ArgumentNullException.ThrowIfNull(post, nameof(Post));

            Posts.Add(post);
        }
    }
}
