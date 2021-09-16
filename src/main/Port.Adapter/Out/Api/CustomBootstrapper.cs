using Nancy;
using Nancy.TinyIoc;
using ei8.EventSourcing.Client;
using ei8.Data.ExternalReference.Application;
using ei8.Data.ExternalReference.Port.Adapter.IO.Process.Services;

namespace ei8.Data.ExternalReference.Port.Adapter.Out.Api
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        public CustomBootstrapper()
        {
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            container.Register<IEventSerializer, EventSerializer>(new EventSerializer());
            container.Register<IEventSourceFactory, EventSourceFactory>();
            container.Register<ISettingsService, SettingsService>();
            container.Register<IItemQueryService, ItemQueryService>();
        }
    }
}
