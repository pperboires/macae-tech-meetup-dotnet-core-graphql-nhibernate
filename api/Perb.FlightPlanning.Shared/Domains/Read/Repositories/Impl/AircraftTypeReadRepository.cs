using System;
using System.Collections.Generic;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories.Impl
{
    public class AircraftTypeReadRepository : IAircraftTypeReadRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AircraftTypeReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public AircraftTypeModel GetById(Guid id)
        {
            return _unitOfWork.GetById<AircraftTypeModel>(id);
        }

        public IQueryable<AircraftTypeModel> GetQuery()
        {
            return _unitOfWork.GetQuery<AircraftTypeModel>();
        }

        public int GetTotal()
        {
            return _unitOfWork.GetQuery<AircraftTypeModel>().Count();
        }
    }
}