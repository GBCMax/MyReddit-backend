using Microsoft.EntityFrameworkCore;
using MyReddit.Core.Interfaces;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly MyRedditDbContext _db;
        public PostRepository(MyRedditDbContext context)
        {
            _db = context;
        }
        public async Task<Guid> Create(Post post, User user, Topic topic)
        {
            var userEntity = await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == user.Email) ?? throw new Exception();

            var topicEntity = await _db.Topics
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == topic.Id);
            if (topicEntity == default)
            {
                topicEntity = new TopicEntity
                {
                    Id = topic.Id,
                    Name = topic.Name
                };
            }

            var postEntity = new PostEntity
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                TopicEntity = topicEntity,
                TopicEntityId = topicEntity.Id,
                UserEntity = userEntity,
                UserEntityId = userEntity.Id
            };

            userEntity.CreatePostEntity(postEntity);
            topicEntity.AddPostEntity(postEntity);

            await _db.SaveChangesAsync();

            return postEntity.Id;
        }
        public async Task<List<Post>> GetByTitle(string partOfTitle) => 
            await _db.Posts
            .AsNoTracking()
            .Where(x => x.Title.ToLower().Contains(partOfTitle.ToLower()))
            .Select(x => Post.Create(x.Id, x.Title, x.Content).Post)
            .ToListAsync();

        public async Task<List<Post>> GetAll()
        {
            var postEntities = await _db.Posts
                .AsNoTracking()
                .ToListAsync();

            var posts = postEntities
                .Select(x => Post.Create(x.Id, x.Title, x.Content).Post)
                .ToList();

            return posts;
        }
        public async Task<Guid> Update(Guid id, string title, string content)
        {
            await _db.Posts
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(y => y
                .SetProperty(x => x.Title, x => title)
                .SetProperty(x => x.Content, x => content));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _db.Posts
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
