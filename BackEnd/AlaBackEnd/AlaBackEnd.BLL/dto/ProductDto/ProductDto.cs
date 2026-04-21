





namespace AlaBackEnd.BLL.dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City {  get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<int> Tags { get; set; } = [];
        public List<ImageDto> Images { get; set; } = [];
        public DateTime DateFrom {  get; set; }
        public DateTime DateTo { get; set; }
        public int UserId { get; set; }
    }
}
