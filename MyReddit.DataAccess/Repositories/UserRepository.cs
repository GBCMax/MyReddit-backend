using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyReddit.Core.Interfaces;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyRedditDbContext _db;
        private readonly IMapper _mapper;
        public UserRepository(MyRedditDbContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAll()
        {
            var userEntities = await _db.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(x => User.Create(x.Id, x.UserName, x.Password, x.Email).User)
                .ToList();

            return users;
        }
        public async Task<Guid> Add(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email
            };
            await _db.Users.AddAsync(userEntity);
            await _db.SaveChangesAsync();

            return userEntity.Id;
        }
        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email.Contains(email));

            if (userEntity == null)
            {
                throw new Exception($"Пользователь с адресом электронной почты '{email}' не найден.");
            }

            return _mapper.Map<User>(userEntity);
        }
        public async Task<Guid> Update(Guid id, string name, string password, string email)
        {
            await _db.Users
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(y => y
                .SetProperty(x => x.UserName, x => name)
                .SetProperty(x => x.Password, x => password)
                .SetProperty(x => x.Email, x => email));

            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _db.Users
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
