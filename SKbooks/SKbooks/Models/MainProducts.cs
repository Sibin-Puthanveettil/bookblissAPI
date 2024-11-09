namespace SKbooksAPI.Models
{
    public class MainProducts
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long Price { get; set; } = 0;
        public string category { get; set; } = "";
        public string author { get; set; } = "";
        public byte[] img { get; set; } =  null;

        public string language { get; set; } = "";

        public int qnt { get; set; } = 0;

        public string Doctype { get; set; } = "";
        public byte[] Doc { get; set; } = null;
        public string doctypeDoc { get; set; } = "";
    }
}
