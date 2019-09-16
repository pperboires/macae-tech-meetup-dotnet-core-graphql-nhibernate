using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Repositories;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Repositories.Impl
{
    public class SolutionWriteRepository :
        BaseWriteRepository<SolutionAggregate, SolutionState>,
        ISolutionWriteRepository
    {
        public SolutionWriteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override SolutionAggregate CreateAggregate(SolutionState state)
        {
            return new SolutionAggregate(state);
        }
    }
}