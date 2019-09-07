using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hachathon.Database
{
    public class EFPlanRepository : BaseRepository, IPlanRepository
    {
        public EFPlanRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IList<Plan>> ListAsync()
        {
            return await context.Plan.ToListAsync();
        }

        public async Task<Plan> GetAsync(int id)
        {
            return await context.Plan.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> IsPlanExist(int id)
        {
            var instance = await GetAsync(id);
            return null != instance;
        }
    }
}