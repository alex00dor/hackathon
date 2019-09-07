using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using hachathon.Resource;
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

        public async Task<IList<User>> ListWithParameters(QueryUserResource query)
        {
            var users = context.User.AsQueryable();
            
            if (query.StatusId.HasValue && query.StatusId > 0)
                users = users.Where(u => u.StatusId == query.StatusId);

            if (query.PlanId.HasValue && query.PlanId > 0)
                users = users.Where(u => u.PlanId == query.PlanId);

            if (query.Name != null)
                users = users.Where(u => (u.Name + u.LastName).ToLower().Contains(query.Name.ToLower()));
            
            if (query.Address != null)
                users = users.Where(u => u.Address.ToLower().Contains(query.Address.ToLower()));

            if (query.Email != null)
                users =  users.Where(u => u.Email.ToLower().Contains(query.Email));

            return await users.Skip((query.Page - query.ItemsPerPage) * query.ItemsPerPage)
                .Take(query.ItemsPerPage).ToListAsync();
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