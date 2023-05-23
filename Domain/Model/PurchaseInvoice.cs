using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PurchaseInvoice
    {
        //فاکتور
        public int ID { get; set; }
        public string Invoicenumber { get; set; }



        public DateTime? Date { get; set; }

        public int IDPerson { get; set; }





        public virtual ICollection<Purchaseinvoiceitems> purchaseinvoiceitems { get; set; }

        public virtual Person? Person { get; set; }
    }
}
