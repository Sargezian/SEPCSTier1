using System.Collections.Generic;

namespace SEPCSTier1.Models
{
    public interface ICart
    {
        public List<Itemss> getCart();
        public void removeProduct(Itemss p);
        public void addProduct(Itemss p);
    }
}