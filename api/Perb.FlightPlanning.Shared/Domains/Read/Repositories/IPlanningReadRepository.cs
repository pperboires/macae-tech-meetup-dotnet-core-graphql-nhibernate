using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories
{
    public interface IPlanningReadRepository
    {
        PlanningModel GetById(Guid id);
        IQueryable<PlanningModel> GetQuery();
    }
}