using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Mobile.Models.Request
{
    public class CreateBlockRequest
    {
        public string CreateForCivilId { get; set; }
        public string CreateByCivilId { get; set; }
        public int TempleteId { get; set; }
        public int PowerAttorneyTypeId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Scope { get; set; }
    }
}
