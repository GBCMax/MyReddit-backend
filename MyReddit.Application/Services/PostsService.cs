using MyReddit.Core.Interfaces.Repo;
using MyReddit.Core.Interfaces.Services;
using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Application.Services
{
    public class PostsService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostsService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Guid> CreatePost(Post post, Guid userId, Guid topicId)
        {
            return await _postRepository.Create(post, userId, topicId);
        }

        public async Task<Guid> DeletePost(Guid id)
        {
            return await _postRepository.Delete(id);
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAll();
        }

        public async Task<List<Post>> GetPostByTitle(string partOfTitle)
        {
            return await _postRepository.GetByTitle(partOfTitle);
        }

        public async Task<List<Post>> GetPostByTopic(Guid topicId)
        {
            return await _postRepository.GetByTopic(topicId);
        }

        public async Task<List<Post>> GetPostByUser(Guid userId)
        {
            return await _postRepository.GetByUser(userId);
        }

        public async Task<Guid> UpdatePost(Guid id, string title, string content)
        {
            return await _postRepository.Update(id, title, content);
        }
    }
}
