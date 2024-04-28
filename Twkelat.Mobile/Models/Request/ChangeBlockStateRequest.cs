namespace Twkelat.Mobile.Models.Request
{
    public class ChangeBlockStateRequest
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
