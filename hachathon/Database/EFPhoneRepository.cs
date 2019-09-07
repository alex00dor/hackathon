using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hachathon.Database
{
    public class EFPhoneRepository : BaseRepository, IPhoneRepository
    {
        public EFPhoneRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IList<Phone>> ListAsync()
        {
            return await context.Phone.Where(p => p.Available).ToListAsync();
        }

        public async Task<Phone> GetAsync(int id)
        {
            return await context.Phone.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async void Update(Phone phone)
        {
            var instance = await context.Phone.FirstOrDefaultAsync(p => p.Id == phone.Id);
            instance.Available = phone.Available;
            context.Phone.Update(instance);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsPhoneExist(int id)
        {
            var phone = await context.Phone.FirstOrDefaultAsync(p => p.Id == id);
            return phone != null;
        }
    }
}