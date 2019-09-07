using System.Collections.Generic;
using System.Threading.Tasks;
using hachathon.Domain.Models;

namespace hachathon.Domain.Repositories
{
    public interface IStatusRepository
    {
        Task<IList<Status>> ListAsync();
    }
}