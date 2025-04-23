using InternPortal.Shared.Contracts.Intern.Requests;
using InternPortal.Shared.Contracts.Intern.Responses;
using Microsoft.AspNetCore.SignalR;

namespace InternPortal.API.Hubs
{
    public class InternHub: Hub
    {
        public async Task Sender(InternRequest model)
            => await Clients.All.SendAsync("Receive", model);

        public async Task Editor(Guid id, InternRequest model)
            => await Clients.All.SendAsync("ReceiveEdit", id, model);

        public async Task Deleter(string id)
            => await Clients.All.SendAsync("ReceiveDelete", id);
    }
}
