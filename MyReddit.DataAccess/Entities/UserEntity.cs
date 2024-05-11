using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            PostsEntity = [];
        }
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual List<PostEntity> PostsEntity { get; set; }
        public void CreatePostEntity(PostEntity postEntity)
        {
            PostsEntity.Add(postEntity);
        }
    }
}
