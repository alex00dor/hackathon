using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;

namespace hachathon.Domain.Repositories
{
    public interface IPhoneRepository
    {
        Task<IList<Phone>> ListAsync();
        Task<Phone> GetAsync(int id);
        void Update(Phone phone);
        Task<bool> IsPhoneExist(int id);
    }
}