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
    public sealed class AirportQueries
    {  
        [Description("Retrieve airport by ID.")]
        public Task<AirportModel> Airport([Inject] IAirportReadRepository repository, Guid id)
        {
            return Task.FromResult(repository.GetById(id));
        }

        [Description("Retrieve airports.")]
        public Task<AirportModel[]> Airports([Inject] IAirportReadRepository repository)
        {
            var query = repository.GetQuery();

            return Task.FromResult(query.ToArray());
        }
    }
}