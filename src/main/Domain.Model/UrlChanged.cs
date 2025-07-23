using CQRSlite.Events;
using Newtonsoft.Json;
using System;

namespace ei8.Data.Mirror.Domain.Model
{
    public class UrlChanged : IEvent
    {
        public readonly string Url;

        public UrlChanged(Guid id, string url)
        {
            this.Id = id;
            this.Url = url;
        }

        public Guid Id { get; set; }

        public int Version { get; set; }

        [JsonProperty(PropertyName = "Timestamp")]
        public DateTimeOffset TimeStamp { get; set; }
    }
}
