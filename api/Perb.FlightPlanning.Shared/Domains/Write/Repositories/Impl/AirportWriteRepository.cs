using Perb.FlightPlanning.Shared.Domains.Write.Aggregates;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.Framework.Domains.Write.Repositories;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Repositories.Impl
{
    public class AirportWriteRepository :
        BaseWriteRepository<AirportAggregate, AirportState>,
        IAirportWriteRepository
    {
        public AirportWriteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override AirportAggregate CreateAggregate(AirportState state)
        {
            return new AirportAggregate(state);
        }
    }
}