using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces
{
    public interface ITopicRepository
    {
        Task<Guid> Add(Topic topic);
        Task<List<Topic>> GetAll();
        Task<List<Topic>> GetByName(string name);
        Task<Guid> Update(Guid id, string name);
        Task<Guid> Delete(Guid id);
    }
}
