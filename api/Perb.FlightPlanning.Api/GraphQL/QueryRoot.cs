using System;
using GraphQL;
using GraphQL.Annotations.Attributes;
using GraphQL.Types;
using Perb.FlightPlanning.Shared.Domains.Read.Models;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;

namespace Perb.FlightPlanning.Api.GraphQL
{
    [GraphQLObject]
    public class QueryRoot 
    {
        private readonly IAircraftTypeReadRepository _aircraftTypeReadRepository;

        public QueryRoot(IAircraftTypeReadRepository aircraftTypeReadRepository)
        {
            _aircraftTypeReadRepository = aircraftTypeReadRepository;
        }
        
        [GraphQLFunc(ReturnType = typeof(AircraftTypeModel))]
        public AircraftTypeModel AircraftTypex([GraphQLArgument(Name = "ID")] string id)
        {
            
            return _aircraftTypeReadRepository.GetById(Guid.Parse(id));
        }
    }
}