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
    public sealed class SolutionQueries
    {
        private static readonly ILog Logger = LogProvider.For<SolutionQueries>();
   
        [Description("Retrieve solution by ID.")]
        public Task<SolutionModel> Solution([Inject] ISolutionReadRepository repository, Guid id)
        {
            return Task.FromResult(repository.GetById(id));
        }

        [Description("Retrieve solutions.")]
        public Task<SolutionModel[]> Solutions([Inject] ISolutionReadRepository repository)
        {
            var query = repository.GetQuery();
            query = query.Fetch(x => x.PlannedFlights);

            return Task.FromResult(query.ToArray());
        }

        [Description("Retrieve solutions by planning.")]
        public Task<SolutionModel[]> SolutionsByPlanning([Inject] ISolutionReadRepository repository, Guid planningId)
        {
            var query = repository.GetQuery().Where(x => x.PlanningId == planningId);
            query = query.Fetch(x => x.PlannedFlights);

            return Task.FromResult(query.ToArray());
        }
    }
}