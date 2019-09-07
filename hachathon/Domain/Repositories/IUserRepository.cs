using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;

namespace hachathon.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IList<User>> ListAsync();
        Task<User> GetAsync(string id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<bool> IsUserExist(string id);
    }
}