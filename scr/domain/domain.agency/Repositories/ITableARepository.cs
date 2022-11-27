using ApiDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Domain.Repositories
{
    public interface ITableARepository
    {
        Task<TableA> GetByIdAsync(int IdAgency);
        Task<ICollection<TableA>> GetTableAAsync();
        Task<TableA> CreateAsync(TableA tableA);
        Task UpdateAsync(TableA tableA);
        Task DeleteAsync(TableA tableA);
    }
}
