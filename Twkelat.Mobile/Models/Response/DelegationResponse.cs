using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Mobile.Models.Response
{
    public class DelegationResponse
    {
        public int Id { get; set; }
        public string TempleteName { get; set; }
        public string CommissionerName { get; set; }
        public byte[] Hash { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool FromMe { get; set; }
    }
}
