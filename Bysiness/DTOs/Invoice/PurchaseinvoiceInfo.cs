using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Person;

namespace Business.DTOs.Invoice
{
    public class PurchaseinvoiceInfo
    {
        public PurchaseinvoiceInfo()
        {
            PurchaseinvoiceitemsInfos = new List<PurchaseinvoiceitemsInfo>();
        }
        public int ID { get; set; }
        public string Invoicenumber { get; set; }
        public DateTime? Date { get; set; }
        public PersonInfo PersonInfo  { get; set; }
        public  ICollection<PurchaseinvoiceitemsInfo> PurchaseinvoiceitemsInfos { get; set; }
    }
}
