using ApiResource.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Application.Services.Interfaces
{
    public interface IResourceService
    {
        Task<ResultService<ResourceDTO>> CreateAsync(ResourceDTO resourceDTO);
        Task<ResultService<ICollection<ResourceDTO>>> GetAsync();
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<ResourceDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ResourceDTO resourceDTO);
    }
}
