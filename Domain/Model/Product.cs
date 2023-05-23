using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }

        public string Mark { get; set; }

        public virtual ICollection<Purchaseinvoiceitems> Aghlamfaktors { get; } = new List<Purchaseinvoiceitems>();



    }
}
