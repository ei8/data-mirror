using CQRSlite.Commands;
using ei8.Data.Mirror.Application;
using System;
using System.Threading.Tasks;

namespace ei8.Data.Mirror.Port.Adapter.In.InProcess
{
    public class ItemAdapter : IItemAdapter
    {
        private readonly ICommandSender commandSender;

        public ItemAdapter(ICommandSender commandSender)
        {
            this.commandSender = commandSender;
        }

        public async Task ChangeUrl(Guid id, string newUrl, Guid authorId, int expectedVersion)
        {
            await this.commandSender.Send(new ChangeUrl(id, newUrl, authorId, expectedVersion));
        }
    }
}
