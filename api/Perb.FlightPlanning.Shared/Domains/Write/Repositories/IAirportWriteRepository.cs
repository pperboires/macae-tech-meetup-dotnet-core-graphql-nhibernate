using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Repositories;

namespace Perb.FlightPlanning.Shared.Domains.Write.Repositories
{
    public interface IAirportWriteRepository : IWriteRepository<AirportAggregate, AirportState>
    {
        
    }
}