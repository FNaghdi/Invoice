using Business.DTOs.Invoice;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IPurchaseinvoiceAction
    {
        PurchaseinvoiceInfo Save(PurchaseinvoiceInfo purchaseinvoiceInfo);
        void Delete(int id);
        List<PurchaseinvoiceInfo> GetPurchaseinvoiceInfos();

        PurchaseinvoiceInfo GetPurchaseInvoice(int id);
    }
}
