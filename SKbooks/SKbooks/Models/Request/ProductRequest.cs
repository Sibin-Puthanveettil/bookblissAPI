namespace SKbooksAPI.Models.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string category { get; set; }
        public byte img { get; set; }
    }
}
