using MyReddit.Core.Interfaces;
using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Application.Services
{
    public class TopicsService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        public TopicsService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task AddTopic(Topic topic)
        {
            await _topicRepository.Add(topic);
        }

        public async Task<Guid> DeleteTopic(Guid id)
        {
            return await _topicRepository.Delete(id);
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            return await _topicRepository.GetAll();
        }

        public async Task<List<Topic>> GetTopicByName(string name)
        {
            return await _topicRepository.GetByName(name);
        }

        public async Task<Guid> UpdateTopic(Guid id, string name)
        {
            return await _topicRepository.Update(id, name);
        }
    }
}
