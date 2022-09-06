namespace M0b3System.API.Common.Instance
{
    public class AspNetUser : IAspNetUser
    {
        public int UserId { get; set; }
    }

    public interface IAspNetUser
    {
        public int UserId { get; set; }

    }
}
