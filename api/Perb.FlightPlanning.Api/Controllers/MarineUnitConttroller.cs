using System;
using Microsoft.AspNetCore.Mvc;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.Framework.Domains.Write;

namespace Perb.FlightPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarineUnitConttroller : ControllerBase
    {
        private readonly ICommandRouter _commandRouter;
        private readonly IMarineUnitReadRepository _marineUnitReadRepository;

        public MarineUnitConttroller(ICommandRouter commandRouter, IMarineUnitReadRepository marineUnitReadRepository)
        {
            _commandRouter = commandRouter;
            _marineUnitReadRepository = marineUnitReadRepository;    
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<MarineUnitModel> Get(Guid id)
        {
            return _marineUnitReadRepository.GetById(id);
        }
    }
}