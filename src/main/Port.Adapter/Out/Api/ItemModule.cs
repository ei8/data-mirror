using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;
using ei8.Data.Mirror.Application;

namespace ei8.Data.Mirror.Port.Adapter.Out.Api
{
    public class ItemModule : NancyModule
    {
        public ItemModule(IItemQueryService itemQueryService) : base("/data/mirrors")
        {
            this.Get("/{itemId}", async (parameters) => new TextResponse(JsonConvert.SerializeObject(
                await itemQueryService.GetItemById(parameters.itemId))
                )
                );
        }
    }
}