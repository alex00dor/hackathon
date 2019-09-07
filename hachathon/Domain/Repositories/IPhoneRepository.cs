using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;

namespace hachathon.Domain.Repositories
{
    public interface IPhoneRepository
    {
        Task<IList<Phone>> ListAsync();
        void Update(Phone phone);
        Task<bool> IsPhoneExist(string id);
    }
}