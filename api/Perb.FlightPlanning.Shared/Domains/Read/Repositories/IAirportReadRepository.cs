using System;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories
{
    public interface IAirportReadRepository
    {
        AirportModel GetById(Guid id);
        IQueryable<AirportModel> GetQuery();
    }
}