using System.Collections.Generic;

namespace Perb.FlightPlanning.Shared.Domains.Write.Services
{
    public interface IExternalEventHandler
    {
        void Handle(IDictionary<string, string> messageAttributes, string messageBody);
    }
}