using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories.Impl
{
    public class MarineUnitReadRepository : IMarineUnitReadRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarineUnitReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public MarineUnitModel GetById(Guid id)
        {
            return _unitOfWork.GetById<MarineUnitModel>(id);
        }

        public IQueryable<MarineUnitModel> GetQuery()
        {
            return _unitOfWork.GetQuery<MarineUnitModel>();
        }
    }
}