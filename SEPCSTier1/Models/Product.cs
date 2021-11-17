namespace SEPCSTier1.Models
{
    public class Product
    {
        public int id { get; set; }
        public string weaponname { get; set; }
        public string modelname { get; set; }
        
        //?
        public string keyname { get; set; }

        public string casename { get; set; }
        public string item_type { get; set; }
        public Product(int id, string weaponname, string modelname)
        {
            this.id = id;
            this.weaponname = weaponname;
            this.modelname = modelname;
        }

    }
}