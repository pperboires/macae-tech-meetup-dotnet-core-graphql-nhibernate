using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using NHibernate.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Queries
{
    [ImplementViewer(OperationType.Query)]
    public sealed class MarineUnitQueries
    {  
        [Description("Retrieve marine unit by ID.")]
        public Task<MarineUnitModel> MarineUnit([Inject] IMarineUnitReadRepository repository, Guid id)
        {
            return Task.FromResult(repository.GetById(id));
        }

        [Description("Retrieve marine units.")]
        public Task<MarineUnitModel[]> MarineUnits([Inject] IMarineUnitReadRepository repository)
        {
            var query = repository.GetQuery();
            query = query.Fetch(x => x.FlightPreferences);
            query = query.Fetch(x => x.FlightDurations);

            return Task.FromResult(query.ToArray());
        }

        [Description("Retrieve marine units with flight duration to airport.")]
        public Task<MarineUnitModel[]> MarineUnitsWithFlightDurationToAirport([Inject] IMarineUnitReadRepository repository, Guid airportId)
        {
            var query = repository.GetQuery().Where(x => x.FlightDurations.Any(a => a.Airport.Id == airportId));
            query = query.Fetch(x => x.FlightPreferences);
            query = query.Fetch(x => x.FlightDurations);

            return Task.FromResult(query.ToArray());
        }
    }
}