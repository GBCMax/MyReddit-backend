using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<Guid> Create(Post post, Guid userId, Guid topicId);
        Task<List<Post>> GetByTitle(string partOfTitle);
        Task<List<Post>> GetByUser(Guid userId);
        Task<List<Post>> GetByTopic(Guid topicId);
        Task<List<Post>> GetAll();
        Task<Guid> Update(Guid id, string title, string content);
        Task<Guid> Delete(Guid id);
    }
}
