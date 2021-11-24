using System.Collections.Generic;

namespace SEPCSTier1.Models
{
    public class Cart : ICart
    {
        private List<Itemss> products;

        public Cart()
        {
            products = new List<Itemss>();
        }

        public List<Itemss> getCart()
        {
            return products;
        }
        
        public void removeProduct(Itemss p)
        {
            products.Remove(p);
        }
        
        public void addProduct(Itemss p)
        {
            products.Add(p);
        }
    }
}