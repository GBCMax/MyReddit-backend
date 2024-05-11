using MyReddit.Core.Interfaces;
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

        public async Task<Guid> CreatePost(Post post, User user, Topic topic)
        {
            return await _postRepository.Create(post, user, topic);
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

        public async Task<Guid> UpdatePost(Guid id, string title, string content)
        {
            return await _postRepository.Update(id, title, content);
        }
    }
}
