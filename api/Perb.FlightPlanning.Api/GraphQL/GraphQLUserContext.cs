using System.Security.Claims;

namespace Perb.FlightPlanning.Api.GraphQL
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}