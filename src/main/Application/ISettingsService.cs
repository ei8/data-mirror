using System;
using System.Collections.Generic;
using System.Text;

namespace ei8.Data.ExternalReference.Application
{
    public interface ISettingsService
    {
        string EventSourcingInBaseUrl { get; }
        string EventSourcingOutBaseUrl { get; }
    }
}
