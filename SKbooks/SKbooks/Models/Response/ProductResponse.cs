namespace SKbooksAPI.Models.Response
{
    public class ProductResponse : BaseReponse
    {

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long Price { get; set; } =0;
        public string category { get; set; } = "";
        public string author { get; set; } = "";
        public string img { get; set; } = "";

        public string language { get; set; } = "";

        public int qnt { get; set; } = 0;

        public string doctype { get; set; } = "";
        public string Doc { get; set; } = "";
        public string doctypeDoc { get; set; } = "";
    }


    public class CustomerResponse : BaseReponse
    {
         
       
        public string id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }

        public string ProfilePic { get; set; }


    }


}
