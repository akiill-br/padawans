using ApiResource.Domain.Entities;
using ApiResource.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByEmailAndPassowrd(string email, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
