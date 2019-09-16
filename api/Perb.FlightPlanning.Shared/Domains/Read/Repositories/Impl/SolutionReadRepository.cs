using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories.Impl
{
    public class SolutionReadRepository : ISolutionReadRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolutionReadRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public SolutionModel GetById(Guid id)
        {
            return _unitOfWork.GetById<SolutionModel>(id);
        }

        public IQueryable<SolutionModel> GetQuery()
        {
            return _unitOfWork.GetQuery<SolutionModel>();
        }
    }
}