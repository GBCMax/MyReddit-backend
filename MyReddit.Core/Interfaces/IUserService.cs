using MyReddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<Guid> AddUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<Guid> UpdateUser(Guid id, string name, string password, string email);
        Task<Guid> DeleteUser(Guid id);
    }
}
