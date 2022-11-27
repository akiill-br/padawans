using ApiDotNet6.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Application.Services.Interfaces
{
    public interface ITableAServices
    {
        Task<ResultService<TableADTO>> CreateAsync(TableADTO tableADTO);
        Task<ResultService<ICollection<TableADTO>>> GetAllAsync();
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService> UpdateAsync(TableADTO tableADTO);
        Task<ResultService<TableADTO>> GetByIdAsync(int id);
    }
}
