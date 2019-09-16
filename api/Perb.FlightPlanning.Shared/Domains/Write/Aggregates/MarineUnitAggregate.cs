using System;
using System.Collections.Generic;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.MarineUnit;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Aggregates;
using Perb.Framework.Infrastructure.Extensions;

namespace Perb.FlightPlanning.Shared.Domains.Write.Aggregates
{
    public class MarineUnitAggregate : BaseAggregate<MarineUnitState>
    {
        public MarineUnitAggregate(MarineUnitState state) : base(state)
        {
        }

        public MarineUnitAggregate(AddMarineUnit cmd)
        {
            State = new MarineUnitState
            {
                Id = cmd.AggregateId
            };
            
            ChangeDemand(cmd.Demand);
            ChangeName(cmd.Name);
            SetFlightDurations(cmd.FlightDurations);
            SetFlightPreferences(cmd.FlightPreferences);
        }

        public void ChangeDemand(int demand)
        {
            State.Demand = demand;
        }

        public void ChangeName(string name)
        {
            State.Name = name;
        }
        
        public void SetFlightDurations(IList<FlightDuration> flightDurations)
        {
            var currentList = State.FlightDurations;
            var newList = flightDurations;
            
            currentList.Merge(newList,
                (input) => new FlightDurationState
                {
                    Id = input.Id,
                    AirportId = input.AirportId,
                    AircraftTypeId = input.AircraftTypeId,
                    RoundTripDurationInMinutes = input.RoundTripDurationInMinutes,
                    MarineUnit = State
                },
                (stateToChange, input) =>
                {   
                    stateToChange.AirportId = input.AirportId;
                    stateToChange.AircraftTypeId = input.AircraftTypeId;
                    stateToChange.RoundTripDurationInMinutes = input.RoundTripDurationInMinutes;
                });
        }
        
        public void SetFlightPreferences(IList<FlightPreference> flightPreferences)
        {
            var currentList = State.FlightPreferences;
            var newList = flightPreferences;
            
            currentList.Merge(newList,
                (input) => new FlightPreferenceState
                {
                    Id = input.Id,
                    DayOfWeek = input.DayOfWeek,
                    Start = input.Start,
                    End = input.End,
                    MarineUnit = State
                },
                (stateToChange, input) =>
                {   
                    stateToChange.DayOfWeek = input.DayOfWeek;
                    stateToChange.Start = input.Start;
                    stateToChange.End = input.End;
                });
        }
    }
}