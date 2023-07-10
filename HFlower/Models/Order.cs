namespace HFlower.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string? Address { get; set; }
        public int? PhoneNum { get; set; }
        public string? Payment { get; set; }
        public int ShipFee { get; set; }
        public int Total { get; set; }
        public string? Note { get; set; }

        

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
