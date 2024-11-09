using System.Net.NetworkInformation;
namespace SKbooksAPI.Models.Response
{
    public class GlobalVars
    {
        public class ResponseStatus
        {
            public int flag { get; set; }
            public int code { get; set; }
            public string message { get; set; }
            public string timeStamp { get; set; }
        }
    }
}
