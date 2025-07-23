using neurUL.Common.Domain.Model;
using neurUL.Common.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using ei8.EventSourcing.Client;
using ei8.Data.Mirror.Common;
using ei8.Data.Mirror.Domain.Model;
using CQRSlite.Domain;

namespace ei8.Data.Mirror.Application
{
    public class ItemQueryService : IItemQueryService
    {
        private readonly ISession session;
        private readonly ISettingsService settingsService;

        public ItemQueryService(ISession session, ISettingsService settingsService)
        {
            AssertionConcern.AssertArgumentNotNull(session, nameof(session));
            AssertionConcern.AssertArgumentNotNull(settingsService, nameof(settingsService));

            this.session = session;
            this.settingsService = settingsService;
        }

        public async Task<ItemData> GetItemById(Guid id, CancellationToken token = default)
        {
            AssertionConcern.AssertArgumentValid(
                g => g != Guid.Empty,
                id,
                Messages.Exception.InvalidId,
                nameof(id)
                );

            var item = await this.session.Get<Item>(id, cancellationToken: token);

            return new ItemData()
            {
                Id = item.Id.ToString(),
                Url = item.Url,
                Version = item.Version
            };
        }
    }
}
