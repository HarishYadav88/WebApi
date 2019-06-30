using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.BusinessLayer.Models;

namespace WebApi.BusinessLayer.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllAsync(CancellationToken ct);
        Task<Group> GetByIdAsync(int id, CancellationToken ct);
        Task<Group> UpdateAsync(Group group, CancellationToken ct);
        Task<Group> AddAsync(Group group, CancellationToken ct);
        Task<Group> RemoveAsync(Group group, CancellationToken ct);
    }
}
