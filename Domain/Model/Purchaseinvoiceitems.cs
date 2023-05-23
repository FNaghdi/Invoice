using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Purchaseinvoiceitems
    {


        public int Id { get; set; }

        public int? Idcommodity { get; set; }

        public int? Number { get; set; }
        public decimal Price { get; set; }

        public int? Idpruchaseinvoice { get; set; }

        public virtual PurchaseInvoice? Purchaseinvoice { get; set; }

        public virtual Product? Product { get; set; }
    }
}

