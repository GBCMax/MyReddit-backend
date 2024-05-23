using MyReddit.Core.Interfaces.Auth;
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
    public class UsersService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            this._jwtProvider = jwtProvider;
        }
        public async Task<Guid> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<Guid> UpdateUser(Guid id, string name, string password, string email)
        {
            return await _userRepository.Update(id, name, password, email);
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, hashedPassword, email);

            if(!string.IsNullOrEmpty(user.Error))
            {
                throw new InvalidOperationException("Can`t register this user!");
            }

            await AddUser(user.User);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await GetUserByEmail(email);

            var result = _passwordHasher.Verify(password, user.Password);

            if(!result)
            {
                throw new Exception("Wrong password or email!");
            }

            var token = _jwtProvider.Generatetoken(user);

            return token;
        }
    }
}
