﻿namespace Domain.Model
{
    public class Person
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }


        public virtual ICollection<PurchaseInvoice> purchaseInvoice { get; } = new List<PurchaseInvoice>();




    }
}
