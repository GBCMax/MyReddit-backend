using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces
{
    public interface IPostService
    {
        Task<Guid> CreatePost(Post post, User user, Topic topic);
        Task<List<Post>> GetPostByTitle(string partOfTitle);
        Task<List<Post>> GetAllPosts();
        Task<Guid> UpdatePost(Guid id, string title, string content);
        Task<Guid> DeletePost(Guid id);
    }
}
