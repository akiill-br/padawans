using ApiResource.Domain.Entities;
using ApiResource.Domain.Repositories;
using ApiResource.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly ApplicationDbContext _db;

        public ResourceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Resource> CreateAsync(Resource resource)
        {
            _db.Add(resource);
            await _db.SaveChangesAsync();
            return resource;
        }

        public async Task DeleteAsync(Resource resource)
        {
            _db.Remove(resource);
            await _db.SaveChangesAsync();
        }

        public async Task<Resource> GetByIdAsync(int id)
        {
            return await _db.Resources.FirstOrDefaultAsync(x => x.ID_RESOURCES == id);
        }

        public async Task<ICollection<Resource>> GetResourcesAsync()
        {
            return await _db.Resources.ToListAsync();
        }

        public async Task UpdateAsync(Resource resource)
        {
            _db.Update(resource);
            await _db.SaveChangesAsync();
        }

    }
}
