using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Repositories;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Repositories.Impl
{
    public class MarineUnitWriteRepository : 
        BaseWriteRepository<MarineUnitAggregate, MarineUnitState>,
        IMarineUnitWriteRepository
    {
        public MarineUnitWriteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override MarineUnitAggregate CreateAggregate(MarineUnitState state)
        {
            return new MarineUnitAggregate(state);
        }
    }
}