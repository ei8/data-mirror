using System;
using System.Collections.Generic;
using System.Text;

namespace ei8.Data.ExternalReference.Domain.Model
{
    public struct Messages
    {
        public struct Exception
        {
            public const string IdEmpty = "Specified Id cannot be empty.";
            public const string UrlEmpty = "Specified URL cannot be null or empty.";
            public const string UrlInvalid = "Specified URL is not valid.";
            public const string SyncVersionLessThanEqualCurrent = "Specified 'syncVersion' is less than or equal to current value.";
            public const string ChangingSyncVersionWhileUrlEmpty = "Cannot set 'SyncVersion' while 'Url' is null or empty.";
        }
    }
}
