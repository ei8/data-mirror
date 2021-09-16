using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;
using ei8.Data.ExternalReference.Application;

namespace ei8.Data.ExternalReference.Port.Adapter.Out.Api
{
    public class ItemModule : NancyModule
    {
        public ItemModule(IItemQueryService itemQueryService) : base("/data/externalreferences")
        {
            this.Get("/{itemId}", async (parameters) => new TextResponse(JsonConvert.SerializeObject(
                await itemQueryService.GetItemById(parameters.itemId))
                )
                );
        }
    }
}