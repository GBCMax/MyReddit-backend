using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Entities
{
    public class TopicEntity
    {
        public TopicEntity()
        {
            PostsEntity = [];
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<PostEntity> PostsEntity { get; set; }
        public void AddPostEntity(PostEntity postEntity)
        {
            PostsEntity.Add(postEntity);
        }
    }
}
