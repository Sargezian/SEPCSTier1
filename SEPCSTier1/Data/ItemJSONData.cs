using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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

        //TODO: IKKE RIGTIG QURRY VI SKIPPER TIER 2 HER CHANGE PLS
        public async Task<IList<Itemss>> GetItemByID(long Id)
        {
            using var client = new GraphQLHttpClient("https://localhost:5001/graphql"
                ,new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = "query ($id: Int!) {items(where: { id: { eq: $id } }) {id,weaponname,weaponURL}}",
                Variables = new
                {
                    id = Id
                }
            };
            
            
            var response =  await client.SendQueryAsync<ResponseItemCollectionType>(request);
            return response.Data.items;
        }
        
    }
}