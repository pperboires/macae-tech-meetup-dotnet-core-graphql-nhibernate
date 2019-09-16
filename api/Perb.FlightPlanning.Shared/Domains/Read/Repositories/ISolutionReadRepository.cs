using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories
{
    public interface ISolutionReadRepository
    {
        SolutionModel GetById(Guid id);
        IQueryable<SolutionModel> GetQuery();
    }
}