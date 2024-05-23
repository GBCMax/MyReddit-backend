using Microsoft.EntityFrameworkCore;
using MyReddit.Core.Interfaces.Repo;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly MyRedditDbContext _db;
        public TopicRepository(MyRedditDbContext context)
        {
            _db = context;
        }
        public async Task<Guid> Add(Topic topic)
        {
            var topicEntity = new TopicEntity
            {
                Id = topic.Id,
                Name = topic.Name
            };
            
            await _db.Topics.AddAsync(topicEntity);
            await _db.SaveChangesAsync();

            return topicEntity.Id;
        }
        public async Task<List<Topic>> GetAll()
        {
            var topicEntities = await _db.Topics
                .AsNoTracking()
                .ToListAsync();

            var topics = topicEntities
                .Select(x => Topic.Create(x.Id, x.Name).Topic)
                .ToList();

            return topics;
        }
        public async Task<List<Topic>> GetByName(string name) => 
            await _db.Topics
            .AsNoTracking()
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .Select(x => Topic.Create(x.Id, x.Name).Topic)
            .ToListAsync();

        public async Task<Guid> Update(Guid id, string name)
        {
            await _db.Topics
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(y => y
                .SetProperty(x => x.Name, name));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _db.Topics
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
