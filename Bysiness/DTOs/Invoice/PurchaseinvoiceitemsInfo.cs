using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Product;

namespace Business.DTOs.Invoice
{
    public class PurchaseinvoiceitemsInfo
    {
        public int Id { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public int? Number { get; set; }
        public decimal Price { get; set; }

    }
}
