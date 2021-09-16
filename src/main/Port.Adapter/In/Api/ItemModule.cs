using CQRSlite.Commands;
using Nancy;
using System;
using ei8.Data.ExternalReference.Application;
using CQRSlite.Domain.Exception;
using neurUL.Common.Api;

namespace ei8.Data.ExternalReference.Port.Adapter.In.Api
{
    public class ItemModule : NancyModule
    {
        public ItemModule(ICommandSender commandSender) : base("/data/externalreferences")
        {
            this.Put("/{itemId}", async (parameters) =>
            {
                return await this.Request.ProcessCommand(
                        async(bodyAsObject, bodyAsDictionary, expectedVersion) =>
                        {
                            await commandSender.Send(new ChangeUrl(
                                Guid.Parse(parameters.itemId.ToString()),
                                bodyAsObject.Url.ToString(),
                                Guid.Parse(bodyAsObject.AuthorId.ToString()),
                                expectedVersion
                            ));
                        },
                        (ex, hsc) => { 
                            HttpStatusCode result = hsc;                   
                            if (ex is ConcurrencyException)
                                result = HttpStatusCode.Conflict;                            
                            return result;
                        },
                        new string[0],
                        "Url",
                        "AuthorId"
                    );
            }
            );
        }
    }
}
