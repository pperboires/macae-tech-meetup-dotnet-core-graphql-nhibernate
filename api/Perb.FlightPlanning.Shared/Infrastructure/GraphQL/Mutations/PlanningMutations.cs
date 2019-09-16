using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Conventions;
using GraphQL.Conventions.Relay;
using Newtonsoft.Json;
using Perb.FlightPlanning.Shared.Domains.Read.Repositories;
using Perb.FlightPlanning.Shared.Domains.Write.Commands.Planning;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject.Solver.Request;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Params;
using Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Results;
using Perb.FlightPlanning.Shared.Logging;
using Perb.Framework.Domains.Write;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Infrastructure.GraphQL.Mutations
{
    [ImplementViewer(OperationType.Mutation)]
    public sealed class PlanningMutations
    {
        private static ILog Logger = LogProvider.For<PlanningMutations>();
        
        private readonly IPlanningReadRepository _planningReadRepository;
        private readonly IAppSettingsRetriever _appSettingsRetriever;
        private readonly ICommandRouter _commandRouter;

        public PlanningMutations(
            ICommandRouter commandRouter,
            IPlanningReadRepository planningReadRepository,
            IAppSettingsRetriever appSettingsRetriever)
        {
            _planningReadRepository = planningReadRepository;
            _appSettingsRetriever = appSettingsRetriever;
            _commandRouter = commandRouter;
        }
        
        [RelayMutation]
        public SavePlanningResult SavePlanning(NonNull<SavePlanningParams> @params)
        {
            _commandRouter.Send(new SavePlanning
            {
                AggregateId = @params.Value.Planning.Value.AggregateId,
                Name = @params.Value.Planning.Value.Name,
                Comments = @params.Value.Planning.Value.Comments,
                AirportId = @params.Value.Planning.Value.AirportId,
                LastFlightType = @params.Value.Planning.Value.LastFlightType,
                FirstFlight = @params.Value.Planning.Value.FirstFlight,
                LastFlight = @params.Value.Planning.Value.LastFlight,
                DaysOfWeek = @params.Value.Planning.Value.DaysOfWeek,
                AircraftContracts = @params.Value.Planning.Value.AircraftContracts.Value,
                MarineUnitIds = @params.Value.Planning.Value.MarineUnitIds.Value
            });

            var planning = _planningReadRepository.GetById(@params.Value.Planning.Value.AggregateId);

            return new SavePlanningResult
            {
                Planning = planning,
                ClientMutationId = @params.Value.ClientMutationId
            };
        }

        [RelayMutation]
        public RemovePlanningsResult RemovePlannings(NonNull<RemovePlanningsParams> @params)
        {
            _commandRouter.Send(new RemovePlannings
            {
                AggregateIds = @params.Value.Ids.Value
            });

            var totalRemoved = @params.Value.Ids.Value.Count;

            return new RemovePlanningsResult
            {
                TotalRemoved = totalRemoved,
                ClientMutationId = @params.Value.ClientMutationId,
                Plannings = _planningReadRepository.GetQuery().ToList()
            };
        }
        
        [RelayMutation]
        public async Task<RequestToSolvePlanningResult> RequestToSolve(NonNull<RequestToSolvePlanningParams> @params)
        {
            var plan = _planningReadRepository.GetById(@params.Value.PlanningId);
                
            var cmd = new PlanFlightsRequest();
            cmd.SolutionScoreChangedSubscribed = true;
            cmd.PlanningId = plan.Id;
            cmd.Name = @params.Value.Name;
            cmd.ClientConnectionId = @params.Value.ClientMutationId;

            cmd.MarineUnits = plan.MarineUnits.Select(x => new MarineUnitRequest
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Demand = x.Demand,
                ToBeAnnounced = false,
                MaxAircraftDimension = 100,
                MaxAircraftWeight = 100,
                
                TimeByAircraftType = x.FlightDurations
                    .Where(w => w.Airport.Id == plan.Airport.Id)
                    .Select(p => new TimeByAircraftType
                    {
                        AircraftType = p.AircraftType.Code,
                        TimeInMinutes = p.RoundTripDurationInMinutes
                    }).ToList(),
                
                FlightPreferenceList = x.FlightPreferences.Select(a => new FlightPreferenceRequest()
                {
                    PeriodRequest = new PeriodRequest
                    {
                        Start = (int)a.Start.TotalMinutes,
                        End = (int)a.End.TotalMinutes,
                        DayOfWeek = a.DayOfWeek.ToString().ToUpper()
                    }
                }).ToList()
                
            }).ToList();


            cmd.FirstDepartureMustBeAtInMinutes = (int)plan.FirstFlight.TotalMinutes;
            cmd.LastFlightValidationType = plan.LastFlightType == LastFlightType.ConsiderArrivalInAirport ? 
                "LANDING_AT_THE_AIRPORT": "TAKE_OFF_FROM_MARINE_UNIT";
            cmd.LastLandingMustBeUntilInMinutes = (int)plan.LastFlight.TotalMinutes;
            cmd.DaysOfWeek = plan.DaysOfWeek.Select(x => x.ToString()).ToList();
            cmd.IntervalBetweenFlightsInMinutes = 5; // TODO colocar isso para ser preenchido no aeroporto.
            cmd.TimeAtMarineUnit = new List<TimeAtMarineUnitRequest>();
            
            cmd.TimeAtMarineUnit.Add(new TimeAtMarineUnitRequest("GP", 15));
            cmd.TimeAtMarineUnit.Add(new TimeAtMarineUnitRequest("MP", 10));


            cmd.UpperLimit = 10;
            cmd.LowerLimit = 2;
            
            cmd.AircraftContracts = plan.AircraftContracts.Select(x => new AircraftContractRequest
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Type = x.AircraftType.Code,
                TotalSeats = x.AircraftType.SeatsByFlightDuration[0].Seats, // TODO implementar esse conceito no motor.
                ConsiderCrewRegulations = x.HasCrewRegulation, 
                MaintenanceTimeInMinutes = (int)x.MaintenanceTime.TotalMinutes,
                TimeByDayInMinutes = (int)x.DailyTime.TotalMinutes,
                Dimension = 50,
                Weight = 50
            }).ToList();

            cmd.DebugEnabled = true;
           
            Logger.InfoFormat("Enqueing {@Command}.", cmd);
                
            // TODO Aqui a gente coloca um comando uma fila para ser processado pelo Solver.
  
            Logger.InfoFormat("Command enqueued.");
            
            return new RequestToSolvePlanningResult
            {
                ClientMutationId = @params.Value.ClientMutationId,
                PlanningId = @params.Value.PlanningId
            };
        } 
    }
}