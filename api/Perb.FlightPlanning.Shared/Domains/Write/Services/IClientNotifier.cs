using Perb.Framework.Domains.Write.Events;

namespace Perb.FlightPlanning.Shared.Domains.Write.Services
{
    public interface IClientNotifier
    {
        void Broadcast(string eventType, IEvent evt);
    }
}