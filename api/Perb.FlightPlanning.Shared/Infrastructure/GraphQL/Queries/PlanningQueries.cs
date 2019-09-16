using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using NHibernate.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Logging;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Queries
{
    [ImplementViewer(OperationType.Query)]
    public sealed class PlanningQueries
    {   
        private static readonly ILog Logger = LogProvider.For<PlanningQueries>();
   
        [Description("Retrieve planning by ID.")]
        public Task<PlanningModel> Planning([Inject] IPlanningReadRepository repository, Guid id)
        {
            return Task.FromResult(repository.GetById(id));
        }

        [Description("Retrieve plannings.")]
        public Task<PlanningModel[]> Plannings([Inject] IPlanningReadRepository repository)
        {
            var query = repository.GetQuery();
            query = query.Fetch(x => x.MarineUnits);
            query = query.Fetch(x => x.AircraftContracts);

            return Task.FromResult(query.ToArray());
        }
    }
}