using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<Guid> Add(User user);
        Task<User> GetByEmail(string email);
        Task<Guid> Update(Guid id, string name, string password, string email);
        Task<Guid> Delete(Guid id);
    }
}
