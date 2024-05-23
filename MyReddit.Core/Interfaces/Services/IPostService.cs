using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces.Services
{
    public interface IPostService
    {
        Task<Guid> CreatePost(Post post, Guid userId, Guid topicId);
        Task<List<Post>> GetPostByTitle(string partOfTitle);
        Task<List<Post>> GetPostByUser(Guid userId);
        Task<List<Post>> GetPostByTopic(Guid topicId);
        Task<List<Post>> GetAllPosts();
        Task<Guid> UpdatePost(Guid id, string title, string content);
        Task<Guid> DeletePost(Guid id);
    }
}
