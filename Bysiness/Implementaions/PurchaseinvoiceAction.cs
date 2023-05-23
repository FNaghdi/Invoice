using Business.DTOs.Invoice;
using Business.Services;
using Domain.Migrations;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Business.Implementaions
{
    public class PurchaseinvoiceAction : IPurchaseinvoiceAction
    {

        PersonContext _personContext;

        public PurchaseinvoiceAction(PersonContext personContext)
        {

            _personContext = personContext;

        }
        public void Delete(int id)
        {
            var purchase = _personContext.purchases.FirstOrDefault(a => a.ID == id);
            if (purchase == null)
                return;
            _personContext.purchases.Remove(purchase);
            _personContext.SaveChanges();
        }

        public PurchaseinvoiceInfo GetPurchaseInvoice(int id)
        {
            var p = _personContext.purchases.Include(a => a.Person).Include(a => a.purchaseinvoiceitems).ThenInclude(a => a.Product).FirstOrDefault(a => a.ID == id);
            PurchaseinvoiceInfo purchaseinvoiceInfo = new PurchaseinvoiceInfo();
            purchaseinvoiceInfo.ID = p.ID;
            purchaseinvoiceInfo.Invoicenumber = p.Invoicenumber;
            purchaseinvoiceInfo.Date = p.Date;
            purchaseinvoiceInfo.PersonInfo = new DTOs.Person.PersonInfo()
            {
                Age = p.Person.Age,
                FirstName = p.Person.FirstName,
                FullName = p.Person.FirstName + " " + p.Person.LastName,
                ID = p.ID,
                LastName = p.Person.LastName,
            };
            foreach (var item in p.purchaseinvoiceitems)
            {
                purchaseinvoiceInfo.PurchaseinvoiceitemsInfos.Add(new PurchaseinvoiceitemsInfo()
                {
                    Id = item.Id,
                    Number = item.Number,
                    Price = item.Price,
                    ProductInfo = new DTOs.Product.ProductInfo()
                    {
                        ID = item.Product.ID,
                        Mark = item.Product.Mark,
                        ProductCode = item.Product.Mark,
                        ProductName = item.Product.ProductName
                    }
                });
            }
            return purchaseinvoiceInfo;

        }

        public List<PurchaseinvoiceInfo> GetPurchaseinvoiceInfos()
        {
            var q = from f in _personContext.purchases.Include(a => a.purchaseinvoiceitems).ThenInclude(a => a.Product).ToList()
                    join p in _personContext.people.ToList() on f.IDPerson equals p.ID

                    select new PurchaseinvoiceInfo
                    {
                        Date = f.Date,
                        ID = f.ID,
                        Invoicenumber = f.Invoicenumber,
                        PersonInfo = new DTOs.Person.PersonInfo()
                        {
                            Age = p.Age,
                            FirstName = p.FirstName,
                            FullName = p.FirstName + " " + p.LastName,
                            ID = p.ID,
                            LastName = p.LastName
                        },
                        PurchaseinvoiceitemsInfos = f.purchaseinvoiceitems.Select(s => new PurchaseinvoiceitemsInfo()
                        {
                            Id = s.Id,
                            Number = s.Number,
                            Price = s.Price,
                            ProductInfo = new DTOs.Product.ProductInfo()
                            {
                                ID = s.Product.ID,
                                Mark = s.Product.Mark,
                                ProductCode = s.Product.ProductCode,
                                ProductName = s.Product.ProductName
                            }

                        }).ToList()

                    };

            return q.ToList();
        }

        public PurchaseinvoiceInfo Save(PurchaseinvoiceInfo purchaseinvoiceInfo)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.Invoicenumber = purchaseinvoiceInfo.Invoicenumber;
            purchaseInvoice.IDPerson = purchaseinvoiceInfo.PersonInfo.ID;
            purchaseinvoiceInfo.Date = purchaseinvoiceInfo.Date;

            purchaseInvoice.purchaseinvoiceitems = new List<Purchaseinvoiceitems>();
            foreach (var item in purchaseinvoiceInfo.PurchaseinvoiceitemsInfos)
            {
                purchaseInvoice.purchaseinvoiceitems.Add(new Purchaseinvoiceitems() {
                Number = item.Number,
                Price=item.Price,
                Idcommodity=item.ProductInfo.ID,
                });
            }
            _personContext.purchases.Add(purchaseInvoice);
            _personContext.SaveChanges();
            return GetPurchaseInvoice(purchaseInvoice.ID);
        }

    }
}
