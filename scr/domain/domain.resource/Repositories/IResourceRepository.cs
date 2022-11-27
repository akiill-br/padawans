using ApiResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Domain.Repositories
{
    public interface IResourceRepository
    {
        Task<Resource> GetByIdAsync(int id);
        Task<ICollection<Resource>> GetResourcesAsync();
        Task<Resource> CreateAsync(Resource resource);
        Task UpdateAsync(Resource resource);
        Task DeleteAsync(Resource resource);
    }
}
