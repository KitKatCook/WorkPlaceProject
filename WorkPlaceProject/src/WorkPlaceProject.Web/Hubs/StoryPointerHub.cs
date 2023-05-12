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

        public async Task StoryPointValueUpdated(Guid sessionId, string sessionCode)
        {
            await Clients.Group(sessionCode).SendAsync("ReceiveStoryPointValueUpdated", sessionId, sessionCode);
        }

        public async Task RevealUserStoryPointValues(string sessionCode)
        {
            await Clients.Group(sessionCode).SendAsync("RevealStoryPointValues", sessionCode);
        }

        public async Task HideUserStoryPointValues(string sessionCode)
        {
            await Clients.Group(sessionCode).SendAsync("HideStoryPointValues", sessionCode);
        }

        public async Task AddToGroup(string sessionCode, string userName)
        {
            _connectionMap.Add(Context.ConnectionId, sessionCode, userName);

            await Groups.AddToGroupAsync(Context.ConnectionId, sessionCode);

            await Clients.Group(sessionCode)
                .SendAsync("ReceiveInfoMessage", $"{userName} has joined the session=[{sessionCode}].");
        }

        public async Task RemoveFromGroup(string sessionCode, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, sessionCode);

            await Clients.Group(sessionCode)
                .SendAsync("ReceiveInfoMessage", $"{userName} has left the session=[{sessionCode}].");

            await Clients.Group(sessionCode).SendAsync("RemoveExitingUserStoryPointValues", sessionCode);

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