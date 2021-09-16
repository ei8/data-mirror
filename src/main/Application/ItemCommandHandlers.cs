using CQRSlite.Commands;
using neurUL.Common.Domain.Model;
using neurUL.Common.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ei8.EventSourcing.Client;
using ei8.EventSourcing.Client.In;
using ei8.Data.ExternalReference.Domain.Model;
using System;

namespace ei8.Data.ExternalReference.Application
{
    public class ItemCommandHandlers : 
        ICancellableCommandHandler<ChangeUrl>
    {
        private readonly IEventSourceFactory eventSourceFactory;
        private readonly ISettingsService settingsService;

        public ItemCommandHandlers(IEventSourceFactory eventSourceFactory, ISettingsService settingsService)
        {
            AssertionConcern.AssertArgumentNotNull(eventSourceFactory, nameof(eventSourceFactory));
            AssertionConcern.AssertArgumentNotNull(settingsService, nameof(settingsService));

            this.eventSourceFactory = eventSourceFactory;
            this.settingsService = settingsService;
        }

        public async Task Handle(ChangeUrl message, CancellationToken token = default(CancellationToken))
        {
            AssertionConcern.AssertArgumentNotNull(message, nameof(message));

            var eventSource = this.eventSourceFactory.Create(
                this.settingsService.EventSourcingInBaseUrl + "/",
                this.settingsService.EventSourcingOutBaseUrl + "/",
                message.AuthorId
                );

            if ((await eventSource.EventStoreClient.Get(message.Id, 0)).Count() == 0)
            {
                var item = new Item(message.Id, message.NewUrl);
                await eventSource.Session.Add(item, token);
            }
            else
            {
                Item item = await eventSource.Session.Get<Item>(message.Id, nameof(item), message.ExpectedVersion, token);
                item.ChangeUrl(message.NewUrl);
            }
            
            await eventSource.Session.Commit(token);
        }
    }
}