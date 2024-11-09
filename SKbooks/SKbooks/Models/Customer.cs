namespace SKbooks.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public long mobile { get; set; } = 0;
        public string Password { get; set; } = "";
        public string Createddate { get; set; } = "";

        public byte[] ProfilePic { get; set; } = null;
    }
}
