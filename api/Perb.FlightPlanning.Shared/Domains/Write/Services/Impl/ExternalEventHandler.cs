using System.Collections.Generic;
using Newtonsoft.Json;
using Perb.FlightPlanning.Shared.Domains.Write.Events;
using Perb.FlightPlanning.Shared.Domains.Write.ValueObject.Solver.Response;
using Perb.Framework.Domains.Write;

namespace Perb.FlightPlanning.Shared.Domains.Write.Services.Impl
{
    public class ExternalEventHandler : IExternalEventHandler
    {
        private readonly ICommandRouter _commandRouter;
        private readonly IClientNotifier _clientNotifier;

        public ExternalEventHandler(ICommandRouter commandRouter, IClientNotifier clientNotifier)
        {
            _commandRouter = commandRouter;
            _clientNotifier = clientNotifier;
        }
        
        public void Handle(IDictionary<string, string> messageAttributes, string messageBody)
        {
            var type = messageAttributes["Type"];

            switch (type)
            {
                case "SolutionScoreChanged":
                    HandleSolutionScoreChanged(messageBody);
                    break;
                    
                case "SolutionCompleted":
                    HandleSolutionCompleted(messageBody);
                    break;
            }
        }
        
        private async void HandleSolutionCompleted(string messageBody)
        {
            var result = JsonConvert.DeserializeObject<FlightPlannerResultResponse>(messageBody);
            
            await _commandRouter.Send(result.ToSaveSolutionCommand());
        }

        private void HandleSolutionScoreChanged(string messageBody)
        {
            var result = JsonConvert.DeserializeObject<SolutionScoreChangedResponse>(messageBody);
            
            _clientNotifier.Broadcast("SolutionScoreChanged", new SolutionScoreChanged
            {
                PlanningId = result.PlanningId,
                NewScore = result.NewScore
            });
        }
    }
}