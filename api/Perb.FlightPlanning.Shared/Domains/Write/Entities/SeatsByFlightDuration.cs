using System;
using GraphQL.Conventions;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Entities
{
    /// <summary>
    /// Total seats by flight duration.
    /// </summary>
    [InputType]
    [Description("Seats by flight duration")]
    public class SeatsByFlightDuration : IIdentifiable
    {
        [Description("ID")]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Total seats.
        /// </summary>
        [Description("Total seats")]
        public int Seats { get; set; }
        
        /// <summary>
        /// Min duration in minutes.
        /// </summary>
        [Description("Min in minutes")]
        public int MinInMinutes { get; set; }
        
        /// <summary>
        /// Max duration in minutes,
        /// </summary>
        [Description("Max in minutes")]
        public int MaxInMinutes { get; set; }
    }
}