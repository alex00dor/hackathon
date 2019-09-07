using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hachathon.Database
{
    public class EFStatusRepository : BaseRepository, IStatusRepository
    {
        public EFStatusRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IList<Status>> ListAsync()
        {
            return await context.Status.ToListAsync();
        }

        public async Task<Status> GetAsync(int id)
        {
            return await context.Status.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> IsStatusExist(int id)
        {
            var instance = await GetAsync(id);
            return instance != null;
        }
    }
}