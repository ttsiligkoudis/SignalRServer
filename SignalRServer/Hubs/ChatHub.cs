using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToAll(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToRoom(string user, string message, string connectionID)
        {
            await Clients.All.SendAsync("ReceiveMessageFromRoom", user, message, connectionID);
        }

        public async Task CheckConnectionID(string connectionID)
        {
            await Clients.All.SendAsync("CheckIfConnectionMatch", connectionID);
        }

        public async Task CheckConnectionIDAnswer(string connectionID, string word, string language)
        {
            await Clients.All.SendAsync("CheckIfConnectionMatchAnswer", connectionID, word, language);
        }

        public async Task SendAlphabetLetter(string connectionID, string letter)
        {
            await Clients.All.SendAsync("ReceiveAlphabetLetter", connectionID, letter);
        }

        public async Task SendResetGame(string connectionID, string word)
        {
            await Clients.All.SendAsync("ResetGame", connectionID, word);
        }
    }
}
