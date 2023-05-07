using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WorkPlaceProject.Web.Hubs
{
    [AllowAnonymous()]
    public class StoryPointerHub : Hub
    {
        private static readonly ConnectionMap _connectionMap = new ();

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
            _connectionMap.Add(Context.ConnectionId, groupName, userName);

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName)
                .SendAsync("ReceiveInfoMessage", $"{userName} has joined the session=[{groupName}].");
        }

        public async Task RemoveFromGroup(string groupName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName)
                .SendAsync("ReceiveInfoMessage", $"{userName} has left the session=[{groupName}].");

            _connectionMap.Remove(Context.ConnectionId);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {

            UserDto? spUser = _connectionMap.Get(Context.ConnectionId);

            if(spUser is not null)
            {
                await RemoveFromGroup(spUser.Group, spUser.Username);
            }

            //_connections.Remove(Context.User.Identity.Name, Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}



/* TODO
 Add reddis cache for session chat history

 
 
 */