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
    }
}