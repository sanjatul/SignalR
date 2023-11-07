using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalR.Data;

namespace SignalR.Hubs
{
    public class BasicChatHub:Hub
    {
        private readonly ApplicationDbContext _context;
        public BasicChatHub( ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessageToAll(string user,string mesage)
        {
            await Clients.All.SendAsync("MessageReceived",user,mesage);
        }
        [Authorize]
        public async Task SendMessageToReceiver(string sender, string receiver, string mesage)
        {
            var userId=_context.Users.FirstOrDefault(u=>u.Email.ToLower()==receiver.ToLower())?.Id;
            if(!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageReceived",sender,mesage);
            }
           
        }
    }
}
