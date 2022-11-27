using ApiResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPassowrd(string email, string password);
    }
}
