﻿using Microsoft.AspNetCore.SignalR;

namespace WorkPlaceProject.Web.Hubs
{
    public class StoryPointerHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveUserMessage", user, message);
        }

        public async Task SendGroupMessage(string group, string user, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveUserMessage", user, message);
        }

        public async Task AddToGroup(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveInfoMessage", $"{userName} has joined the session=[{groupName}].");
        }

        public async Task RemoveFromGroup(string groupName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveInfoMessage", $"{userName} has left the session=[{groupName}].");
        }

        public override Task OnConnectedAsync()
        {
            UserHandler.ConnectedUsers.Add(Context.ConnectionId, "");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await RemoveFromGroup("", "");

            UserHandler.ConnectedUsers.Remove(Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }

    public static class UserHandler
    {
        public static Dictionary<string, string> ConnectedUsers = new Dictionary<string, string>();
    }

}
