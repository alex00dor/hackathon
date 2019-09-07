using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;
using hachathon.Resource;

namespace hachathon.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IList<User>> ListAsync();
        Task<IList<User>> ListWithParameters(QueryUserResource query);
        Task<User> GetAsync(string id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<bool> IsUserExist(string id);
    }
}