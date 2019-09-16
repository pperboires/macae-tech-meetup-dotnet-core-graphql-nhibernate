using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories.Impl
{
    public class AirportReadRepository : IAirportReadRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirportReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public AirportModel GetById(Guid id)
        {
            return _unitOfWork.GetById<AirportModel>(id);
        }

        public IQueryable<AirportModel> GetQuery()
        {
            return _unitOfWork.GetQuery<AirportModel>();
        }

    }
}