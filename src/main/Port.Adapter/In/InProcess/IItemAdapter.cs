using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ei8.Data.ExternalReference.Port.Adapter.In.InProcess
{
    public interface IItemAdapter
    {
        Task ChangeUrl(Guid id, string newUrl, Guid authorId, int expectedVersion);
    }
}
