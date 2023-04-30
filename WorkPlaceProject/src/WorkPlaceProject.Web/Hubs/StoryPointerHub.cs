using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Graph;
using Microsoft.Identity.Web;


namespace WorkPlaceProject.Web.Hubs
{
    [AllowAnonymous()]
    public class StoryPointerHub : Hub
    {
        private static readonly ConnectionMapping<string> _connections = new ();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveUserMessage", user, message);
        }

        public async Task SendGroupMessage(string group, string user, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveUserMessage", user, message);
        }

        public async Task SendGroupInfoMessage(string group, string user, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveInfoMessage", user, message);
        }


        public async Task AddToGroup(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName)
                .SendAsync("ReceiveInfoMessage", $"{userName} has joined the session=[{groupName}].");
        }

        public async Task RemoveFromGroup(string groupName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName)
                .SendAsync("ReceiveInfoMessage", $"{userName} has left the session=[{groupName}].");
        }

        public override Task OnConnectedAsync()
        {
            //_connections.Add(Context.User.Identity.Name, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await RemoveFromGroup("", "");

            //_connections.Remove(Context.User.Identity.Name, Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
