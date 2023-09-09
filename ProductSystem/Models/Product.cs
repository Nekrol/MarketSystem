using System.ComponentModel;

namespace ProductSystem.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int VendorId { get; set; }
        public string Description { get; set; }
    }
}
