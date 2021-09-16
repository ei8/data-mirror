using neurUL.Common.Domain.Model;
using System;

namespace ei8.Data.ExternalReference.Domain.Model
{
    /// <summary>
    /// Represents an Item.
    /// </summary>
    public class Item : AssertiveAggregateRoot
    {
        private Item() { }

        /// <summary>
        /// Constructs an Item.
        /// </summary>
        /// <param name="id"></param>
        public Item(Guid id, string url)
        {
            AssertionConcern.AssertArgumentValid(i => i != Guid.Empty, id, Messages.Exception.IdEmpty, nameof(id));
            this.ValidateUrl(url, nameof(url));

            this.Id = id;
            this.ApplyChange(new UrlChanged(id, url));
        }
        
        public string Url { get; private set; }

        public void ChangeUrl(string newUrl)
        {
            this.ValidateUrl(newUrl, nameof(newUrl));

            if (newUrl != this.Url)
                base.ApplyChange(new UrlChanged(this.Id, newUrl));
        }

        private void ValidateUrl(string url, string fieldName)
        {
            AssertionConcern.AssertArgumentNotEmpty(url, Messages.Exception.UrlEmpty, nameof(url));
            AssertionConcern.AssertArgumentValid(u =>
                Uri.TryCreate(u, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps),
                url,
                Messages.Exception.UrlInvalid,
                fieldName
            );
        }

        private void Apply(UrlChanged e)
        {
            this.Url = e.Url;
        }
    }
}
