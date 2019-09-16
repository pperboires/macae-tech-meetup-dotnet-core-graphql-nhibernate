using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories.Impl
{
    public class PlanningReadRepository : IPlanningReadRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanningReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public PlanningModel GetById(Guid id)
        {
            return _unitOfWork.GetById<PlanningModel>(id);
        }

        public IQueryable<PlanningModel> GetQuery()
        {
            return _unitOfWork.GetQuery<PlanningModel>();
        }
    }
}