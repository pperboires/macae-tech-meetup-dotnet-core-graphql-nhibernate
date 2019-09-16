using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Repositories;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Repositories.Impl
{
    public class AircraftTypeWriteRepository : 
        BaseWriteRepository<AircraftTypeAggregate, AircraftTypeState>,
        IAircraftTypeWriteRepository
    {
        public AircraftTypeWriteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override AircraftTypeAggregate CreateAggregate(AircraftTypeState state)
        {
            return new AircraftTypeAggregate(state);
        }
    }
}