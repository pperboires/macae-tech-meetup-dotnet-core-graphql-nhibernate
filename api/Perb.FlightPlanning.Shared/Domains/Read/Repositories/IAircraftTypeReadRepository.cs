using System;
using System.Collections.Generic;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Read.Models;

namespace Perb.FlightPlanning.Shared.Domains.Read.Repositories
{
    public interface IAircraftTypeReadRepository
    {
        AircraftTypeModel GetById(Guid id);
        IQueryable<AircraftTypeModel> GetQuery();
        int GetTotal();
    }
}