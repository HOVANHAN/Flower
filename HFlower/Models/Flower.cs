namespace HFlower.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public double? Price { get; set; }
        public string? Color { get; set; }
        public string? Meaning { get; set; }
        public string? ImgLink { get; set; }


        public Category? categories { get; set; }
    }
}
