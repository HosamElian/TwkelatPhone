namespace Twkelat.Mobile.Models.ViewModels
{
    public class DelegationVM
    {
        public int Id { get; set; }
        public string TempleteName { get; set; }
        public string CommissionerName { get; set; }
        public byte[] Hash { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool FromMe { get; set; }

        public string Color
        {
            get
            {
                if (ExpirationDate < DateTime.Today)
                    return "#008800";
                else
                {
                    return "#FF0000";
                }
            }
            set
            {
                Color = value;
            }
        }

    }
}
