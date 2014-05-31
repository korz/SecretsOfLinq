namespace ObjectsAsTrees.Data
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ExtendedTotal { get; set; }
    }
}
