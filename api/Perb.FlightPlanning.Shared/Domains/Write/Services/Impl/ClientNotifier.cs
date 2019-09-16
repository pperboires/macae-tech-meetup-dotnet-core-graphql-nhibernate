using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Perb.Framework.Domains.Write.Events;
using Perb.Framework.Infrastructure;

namespace Perb.FlightPlanning.Shared.Domains.Write.Services.Impl
{
    public class ClientNotifier : IClientNotifier
    {
        private readonly IAppSettingsRetriever _appSettingsRetriever;

        public ClientNotifier(IAppSettingsRetriever appSettingsRetriever)
        {
            _appSettingsRetriever = appSettingsRetriever;
        }
        
        public async void Broadcast(string eventType, IEvent evt)
        {  
            using (var wsc = new ClientWebSocket())
            {
                var uri = new Uri(_appSettingsRetriever.GetValue("WebSocket:Url"));

                await wsc.ConnectAsync(uri, CancellationToken.None);
            
                var evtToSend = new
                {
                    PayloadType = eventType,
                    Payload = Serialize(evt)
                };
                
                var buffer = System.Text.Encoding.UTF8.GetBytes(
                    JsonConvert.SerializeObject(new {action = "sendMessage", data = Serialize(evtToSend)}));

                var message = new ArraySegment<byte>(buffer);

                await wsc.SendAsync(message, WebSocketMessageType.Text, true, CancellationToken.None);

                await wsc.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
        }
        
        
        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
    
}