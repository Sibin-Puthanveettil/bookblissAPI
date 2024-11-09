namespace SKbooksAPI.Models.Request
{
    public class RegisterReqest
    {
        public string Name { get; set; }
        public long mobile { get; set; }
        public string Password { get; set; }
        public string Createddate { get; set; }

        public byte[] ProfilePic { get; set; } = null;

    }
}
