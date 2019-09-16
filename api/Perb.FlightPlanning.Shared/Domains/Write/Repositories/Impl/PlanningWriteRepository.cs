using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Repositories;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Repositories.Impl
{
    public class PlanningWriteRepository :
        BaseWriteRepository<PlanningAggregate, PlanningState>,
        IPlanningWriteRepository
    {
        public PlanningWriteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override PlanningAggregate CreateAggregate(PlanningState state)
        {
            return new PlanningAggregate(state);
        }
    }
}