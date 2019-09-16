using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentNHibernate.Utils;
using GraphQL;
using GraphQL.Conventions;
using Microsoft.AspNetCore.Mvc;
using Perb.FlightPlanning.Api.Logging;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;

namespace Perb.FlightPlanning.Api.Controllers
{
    [ApiController]
    [Route("api/graph")]
    public class GraphController : ControllerBase
    {
        private static readonly ILog Logger = LogProvider.For<GraphController>();
        
        private readonly GraphQLEngine _engine;
        private readonly IUserContext _userContext;
        private readonly IDependencyInjector _injector;
        
        public GraphController(GraphQLEngine engine, IUserContext userContext, IDependencyInjector injector)
        {
            _engine = engine;
            _userContext = userContext;
            _injector = injector;
        }

        [HttpOptions]
        [Route("")]
        public OkResult Options()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post()
        {
           
            string requestBody;
            using (var reader = new StreamReader(Request.Body))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            
            Logger.InfoFormat("Post: {Body}", requestBody);

            try
            {
                ExecutionResult result = await _engine
                    .NewExecutor()
                    .WithUserContext(_userContext)
                    .WithDependencyInjector(_injector)
                    .WithRequest(requestBody)
                    .Execute();

                var responseBody = _engine.SerializeResult(result);

                HttpStatusCode statusCode = HttpStatusCode.OK;

                if (result.Errors?.Any() ?? false)
                {

                    Exception ex = result.Errors.First();

                    Logger.ErrorException("Ocorreu um erro durante execução do GraphQL.", ex);

                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        Logger.ErrorException("Ocorreu um erro durante execução do GraphQL.", ex);
                    }

                    statusCode = HttpStatusCode.InternalServerError;

                    if (result.Errors.Any(x => x.Code == "VALIDATION_ERROR"))
                    {
                        statusCode = HttpStatusCode.BadRequest;
                    }
                    else if (result.Errors.Any(x => x.Code == "UNAUTHORIZED_ACCESS"))
                    {
                        statusCode = HttpStatusCode.Forbidden;
                    }
                }

                return new ContentResult
                {
                    Content = responseBody,
                    ContentType = "application/json; charset=utf-8",
                    StatusCode = (int) statusCode
                };
            }
            catch (Exception e)
            { 
                Logger.ErrorException("Ocorreu um erro durante execução do GraphQL.", e);

                return new ContentResult
                {
                    Content = e.Message,
                    ContentType = "application/json; charset=utf-8",
                    StatusCode = (int) HttpStatusCode.InternalServerError
                };
            }
        }


    }
}