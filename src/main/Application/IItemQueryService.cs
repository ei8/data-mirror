using System;
using System.Threading;
using System.Threading.Tasks;
using ei8.Data.ExternalReference.Common;

namespace ei8.Data.ExternalReference.Application
{
    public interface IItemQueryService
    {
        Task<ItemData> GetItemById(Guid id, CancellationToken token = default);
    }
}
