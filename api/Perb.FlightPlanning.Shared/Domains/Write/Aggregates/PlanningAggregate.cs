using System;
using System.Collections.Generic;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Airport;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Planning;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Aggregates;
using Perb.Framework.Infrastructure.Extensions;

namespace Perb.FlightPlanning.Shared.Domains.Write.Aggregates
{
    public class PlanningAggregate : BaseAggregate<PlanningState>
    {
        public PlanningAggregate(PlanningState state) : base(state)
        {
            
        }

        public PlanningAggregate(Guid id)
        {
            State = new PlanningState
            {
                Id = id
            };
        }

        public void ChangeName(string name)
        {
            State.Name = name;
        }

        public void ChangeComments(string comments)
        {
            State.Comments = comments;
        }

        public void ChangeAirportId(Guid airportId)
        {
            State.AirportId = airportId;
        }
        
        public void ChangeFirstFlight(TimeSpan firstFlight)
        {
            State.FirstFlight = firstFlight;
        }

        public void ChangeLastFlight(TimeSpan lastFlight)
        {
            State.LastFlight = lastFlight;
        }

        public void ChangeLastFlightType(LastFlightType type)
        {
            State.LastFlightType = type;
        }

        public void ChangeMarineUnitIds(IList<Guid> marineUnitIds)
        {
            State.MarineUnitIds.Merge(marineUnitIds);
        }

        public void ChangeDaysOfWeek(IList<DayOfWeek> daysOfWeek)
        {
            State.DaysOfWeek.Merge(daysOfWeek);
        }

        public void ChangeAircraftContracts(IList<AircraftContract> aircraftContracts)
        {
            State.AircraftContracts.Merge(aircraftContracts,
                (input) => new AircraftContractState
                {
                    Id = input.Id,
                    Name = input .Name,
                    AircraftTypeId = input.AircraftTypeId,
                    MaintenanceTime = input.MaintenanceTime,
                    DailyTime = input.DailyTime,
                    HasCrewRegulation = input.HasCrewRegulation,
                    Planning = State
                },
                (stateToChange, input) =>
                {   
                    stateToChange.Name = input.Name;
                    stateToChange.DailyTime = input.DailyTime;
                    stateToChange.MaintenanceTime = input.MaintenanceTime;
                    stateToChange.AircraftTypeId = input.AircraftTypeId;
                    stateToChange.HasCrewRegulation = input.HasCrewRegulation;
                });
        }
    }
}