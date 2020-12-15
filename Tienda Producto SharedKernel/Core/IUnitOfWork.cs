using System.Threading;
using System.Threading.Tasks;

namespace Tienda_Inventario_SharedKernel.Core
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}