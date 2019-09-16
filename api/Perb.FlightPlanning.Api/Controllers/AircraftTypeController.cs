using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.AircraftType;
using Perb.Framework.Domains.Write;

namespace Perb.FlightPlanning.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftTypeController : ControllerBase
    {
        private readonly ICommandRouter _commandRouter;
        private readonly IAircraftTypeReadRepository _aircraftTypeReadRepository;

        public AircraftTypeController(ICommandRouter commandRouter, IAircraftTypeReadRepository aircraftTypeReadRepository)
        {
            _commandRouter = commandRouter;
            _aircraftTypeReadRepository = aircraftTypeReadRepository;
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<AircraftTypeModel> Get(Guid id)
        {
            return _aircraftTypeReadRepository.GetById(id);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(AddAircraftType cmd)
        {
            // TODO tratar esse async..
            await _commandRouter.Send(cmd);
            return Ok();
        } 
        
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(UpdateAircraftType cmd)
        {
            // TODO tratar esse async..
            _commandRouter.Send(cmd);
            return Ok();
        } 
        
        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(RemoveAircraftTypes cmd)
        {
            // TODO tratar esse async..
            _commandRouter.Send(cmd);
            return Ok();
        } 
    }
}