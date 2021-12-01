using System.Collections.Generic;
using System.Threading.Tasks;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public interface IChatData
    {
        Task<IList<Chat>> GetChat();

        Task<Chat> GetChatByID(long id);

        void AddChat(Chat chat);

    }
}