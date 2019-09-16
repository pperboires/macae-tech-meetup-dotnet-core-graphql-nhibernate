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
    public sealed class AircraftTypeQueries
    {  
        [Description("Retrieve aircraft type by ID.")]
        public Task<AircraftTypeModel> AircraftType([Inject] IAircraftTypeReadRepository repository, Guid id)
        {
            return Task.FromResult(repository.GetById(id));
        }

        [Description("Retrieve aircraft types.")]
        public Task<AircraftTypeModel[]> AircraftTypes([Inject] IAircraftTypeReadRepository repository)
        {
            var query = repository.GetQuery();

            query = query.Fetch(x => x.SeatsByFlightDuration);

            return Task.FromResult(query.ToArray());
        }
    }
}