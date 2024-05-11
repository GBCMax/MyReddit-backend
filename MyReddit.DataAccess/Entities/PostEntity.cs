using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid TopicEntityId { get; set; }
        public virtual TopicEntity TopicEntity { get; set; }
        public Guid UserEntityId { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}
