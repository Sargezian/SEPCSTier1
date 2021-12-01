using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEPCSTier1.Graphql;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class ChatData : IChatData
    {
        private GraphqlClient graphqlClient;
        private List<Chat> chatList = new List<Chat>();


        public ChatData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }

        public async Task<IList<Chat>> GetChat()
        {
            var result = await graphqlClient.GetChat.ExecuteAsync();

            chatList = result.Data.Chat.Select(chat => new Chat
            {
                id = chat.Id,
                Chatlist = chat.Chatlist,
                user_id = chat.User_id
            }).ToList();

            return chatList;
        }


        public async Task<Chat> GetChatByID(long Id)
        {
            var result = await graphqlClient.ChatById.ExecuteAsync(Id);
    
            Chat chat = new Chat
            {
                id = result.Data.ChatById.Id,
                Chatlist = result.Data.ChatById.Chatlist,
                user_id = result.Data.ChatById.User_id
        
            };
            return chat;
        }


        public async void AddChat(Chat chat)
        {
            await graphqlClient.AddChat.ExecuteAsync(chat.id,chat.Chatlist,chat.user_id);
        }

    }
}