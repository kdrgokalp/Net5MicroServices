using Microsoft.AspNetCore.SignalR;

using System.Threading.Tasks;

namespace MicroService.Sourcing.Hubs
{
    public class AuctionHub : Hub
    {
        //Herkes herşeyi görmesin. Grup oluştrulacak.
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendBidAsync(string groupName, string user, string bid) //invoke
        {
            await Clients.Group(groupName).SendAsync("Bids", user, bid); //on
        }
    }
}
