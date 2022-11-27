using ApiDotNet6.Domain.Entities;
using ApiDotNet6.Domain.Repositories;
using ApiDotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Infra.Data.Repositories
{
    public class TableARepository : ITableARepository
    {
        private readonly ApplicationDbContext _db;

        public TableARepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TableA> CreateAsync(TableA tableA)
        {
            _db.Add(tableA);
            await _db.SaveChangesAsync();
            return tableA;
        }

        public async Task DeleteAsync(TableA tableA)
        {
            _db.Remove(tableA);
            await _db.SaveChangesAsync();
        }

        public async Task<TableA> GetByIdAsync(int IdAgency)
        {
            return await _db.TableAs.FirstOrDefaultAsync(x => x.IdAgency == IdAgency);
        }

        public async Task<ICollection<TableA>> GetTableAAsync()
        {
            return await _db.TableAs.ToListAsync();
        }

        public async Task UpdateAsync(TableA tableA)
        {
            _db.Update(tableA);
            await _db.SaveChangesAsync();   
        }
    }
}
