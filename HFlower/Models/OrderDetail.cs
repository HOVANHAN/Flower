namespace HFlower.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int FlowerId { get; set; }
        public Flower Flower { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        

    }
}
