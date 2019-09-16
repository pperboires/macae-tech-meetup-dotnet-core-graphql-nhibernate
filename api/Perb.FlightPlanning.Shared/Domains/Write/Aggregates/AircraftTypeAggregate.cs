using System;
using System.Collections.Generic;
using System.Linq;
using Perb.FlightPlanning.Shared.Domains.Write.Entities;
using Perb.FlightPlanning.Shared.Domains.Write.Exceptions;
using Perb.FlightPlanning.Shared.Domains.Write.States;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.Framework.Domains.Write.Aggregates;
using Perb.Framework.Infrastructure.Extensions;

namespace Perb.FlightPlanning.Shared.Domains.Write.Aggregates
{
    public class AircraftTypeAggregate : BaseAggregate<AircraftTypeState>
    {
        public AircraftTypeAggregate(AircraftTypeState state) : base(state)
        {
        }

        public AircraftTypeAggregate(Guid id, string code, string name)
        {
            State = new AircraftTypeState
            {
                Id = id,
                Code = code,
                Name = name
            };
        }

        public void ChangeCode(string code)
        {
            State.Code = code;
        }

        public void ChangeName(string name)
        {
            State.Name = name;
        }

        public void SetSeatsByDuration(IList<SeatsByFlightDuration> seatsByDurationList)
        {   
            var currentList = State.SeatsByFlightDuration;
            var newList = seatsByDurationList;

            currentList.Merge(newList,
                (input) => new SeatsByFlightDurationState
                {
                    Id = input.Id,
                    Seats = input.Seats,
                    MinInMinutes = input.MinInMinutes,
                    MaxInMinutes = input.MaxInMinutes,
                    AircraftType = State
                },
                (stateToChange, input) =>
                {   
                    stateToChange.Seats = input.Seats;
                    stateToChange.MinInMinutes = input.MinInMinutes;
                    stateToChange.MaxInMinutes = input.MaxInMinutes;
                });
                
            
            /*
            foreach (var seatsByDuration in seatsByDurationList)
            {
                if (State.SeatsByFlightDuration.Any(x => x.MinInMinutes <= seatsByDuration.MaxInMinutes &&
                                                         x.MaxInMinutes >= seatsByDuration.MinInMinutes))
                {
                    throw new DomainException(DomainExceptionCode.SeatsByFlightDurationConflict);
                }
            }
            */
        }
    }
}