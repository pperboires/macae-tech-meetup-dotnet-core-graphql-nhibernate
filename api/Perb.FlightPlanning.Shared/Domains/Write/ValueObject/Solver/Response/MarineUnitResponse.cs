using System;
using Newtonsoft.Json;

namespace Perb.FlightPlanning.Shared.Domains.Write.ValueObject.Solver.Response
{
    public class MarineUnitResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}