namespace Northwind_API.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
