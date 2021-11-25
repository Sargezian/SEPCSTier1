
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SEPCSTier1.Graphql;
using SEPCSTier1.Models;

namespace SEPCSTier1.Data
{
    public class ItemJSONData : IItemData
    {
        
        private GraphqlClient graphqlClient;
        private List<Itemss> Itemslist = new List<Itemss>();


        public ItemJSONData(GraphqlClient graphqlClient)
        {
            this.graphqlClient = graphqlClient;
        }


        public async Task<IList<Itemss>> GetItems()
        {
            var result = await graphqlClient.GetItems.ExecuteAsync();

            Itemslist = result.Data.Items.Select(items => new Itemss
            {
                id = items.Id,
                weaponname = items.Weaponname,
                weaponURL = items.WeaponURL

            }).ToList();
            
            return Itemslist;
        }

        
        public async Task<Itemss> GetItemByID(long Id)
        {
           var result = await graphqlClient.ItemById.ExecuteAsync(Id);
           

           Itemss itemss = new Itemss
           {
               id = result.Data.ItemById.Id,
               weaponname = result.Data.ItemById.Weaponname,
               weaponURL = result.Data.ItemById.WeaponURL
               
           };
           
            return itemss;

        }
        
    }
}