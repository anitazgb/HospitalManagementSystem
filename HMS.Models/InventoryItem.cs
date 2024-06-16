namespace HMS.Models
{
    public class InventoryItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsLowStock => Quantity < 10;
    }
}
