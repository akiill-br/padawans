using ApiResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);

    }
}
