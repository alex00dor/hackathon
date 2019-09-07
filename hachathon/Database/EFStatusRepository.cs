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
    }
}