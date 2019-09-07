using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hachathon.Database
{
    public class EFUserRepository : BaseRepository, IUserRepository
    {
        public EFUserRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IList<User>> ListAsync()
        {
            return await context.User.ToListAsync();
        }

        public async Task<User> GetAsync(string id)
        {
            return await context.User.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddUserAsync(User user)
        {
            context.User.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var instance = await context.User.FirstOrDefaultAsync(p => p.Id == user.Id);
            if(instance == null)
                throw new Exception("User not found");

            instance.Name = user.Name;
            instance.LastName = user.LastName;
            instance.PlanId = user.PlanId;
            instance.PhoneId = user.PhoneId;
            instance.Address = user.Address;
            instance.Email = user.Email;
            instance.Ssn = user.Ssn;
            instance.StatusId = user.StatusId;
            instance.Score = user.Score;

            context.Update(instance);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsUserExist(string id)
        {
            var instance = await context.User.FirstOrDefaultAsync(p => p.Id == id);
            return instance != null;
        }
    }
}