using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class ItemJSONData : IItemData
    {
        public async Task<IList<Itemss>> GetItems()
        {
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                , new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = "query{items{id,weaponname,weaponURL}}"
                
            };
            var response = await client.SendQueryAsync<ResponseItemCollectionType>(request);
            
            return response.Data.items;
            
            
        }
    }
}