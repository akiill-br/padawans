using Frwk.ApiDotNet6.Domain.Entities;
using Frwk.ApiDotNet6.Domain.Repositories;
using Frwk.ApiDotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frwk.ApiDotNet6.Infra.Data.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ApplicationDbContext _db;

        public CampaignRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Campaign> CreateAsync(Campaign campaign)
        {
            _db.Add(campaign);
            await _db.SaveChangesAsync();
            return campaign;
        }

        public async Task DeleteAsync(Campaign campaign)
        {
            _db.Remove(campaign);
            await _db.SaveChangesAsync();   
        }

        //public async Task<ICollection<Campaign>> GetAllCampaignAsync()
        //{
        //    return await _db.Campaigns.ToListAsync();
        //}

        //public async Task<Campaign> GetByIdAsync(int id)
        //{
        //    return await _db.Campaigns.FirstOrDefaultAsync(x =>x.IdCampaign==id);
        //}

        public async Task UpdateAsync(Campaign campaign)
        {
           _db.Update(campaign);
            await _db.SaveChangesAsync(); 
        }
    }
}
