using Microsoft.AspNetCore.SignalR.Client;

namespace InternPortal.Client.Components.SignalR
{
    public class InternHub
    {
        private readonly HubConnection Hub;

        public InternHub(IConfiguration configuration)
        {
            var apiBaseUrl = configuration["ApiBaseUrl"];
            var hubPath = configuration["HubSignalRPath"];

            Hub = new HubConnectionBuilder()
                .WithUrl($"{apiBaseUrl}{hubPath}")
                .WithAutomaticReconnect()
                .Build();

            Hub.StartAsync();
        }

        public async void Sender(string methodName, object data)
            => await Hub.InvokeAsync(methodName, data);

        public async void Receiver<T>(string methodName, Action<T> action)
        {
            Hub.On<T>(methodName, action);
        }
    }
}