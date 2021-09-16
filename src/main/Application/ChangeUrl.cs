using CQRSlite.Commands;
using neurUL.Common.Domain.Model;
using System;

namespace ei8.Data.ExternalReference.Application
{
    public class ChangeUrl : ICommand
    {
        public ChangeUrl(Guid id, string newUrl, Guid authorId, int expectedVersion)
        {
            AssertionConcern.AssertArgumentValid(
                g => g != Guid.Empty,
                id,
                Messages.Exception.InvalidId,
                nameof(id)
                );
            AssertionConcern.AssertArgumentNotNull(newUrl, nameof(newUrl));
            AssertionConcern.AssertArgumentValid(
                g => g != Guid.Empty,
                authorId,
                Messages.Exception.InvalidId,
                nameof(authorId)
                );
            AssertionConcern.AssertArgumentValid(
                i => i >= 0,
                expectedVersion,
                Messages.Exception.InvalidExpectedVersion,
                nameof(expectedVersion)
                );

            this.Id = id;
            this.NewUrl = newUrl;
            this.AuthorId = authorId;
            this.ExpectedVersion = expectedVersion;
        }

        public Guid Id { get; private set; }

        public string NewUrl { get; private set; }

        public Guid AuthorId { get; set; }

        public int ExpectedVersion { get; set; }
    }
}
