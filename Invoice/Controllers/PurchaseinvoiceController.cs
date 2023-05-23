using Business.DTOs.Invoice;
using Business.Implementaions;
using Business.Services;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Implementaions;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PurchaseinvoiceController : ControllerBase
    {



        private readonly ILogger<PurchaseinvoiceController> _logger;
        private readonly IPurchaseinvoiceAction _PurchaseinvoiceAction;
        public PurchaseinvoiceController(ILogger<PurchaseinvoiceController> logger, IPurchaseinvoiceAction PurchaseinvoiceAction)
        {
            _logger = logger;

            _PurchaseinvoiceAction = PurchaseinvoiceAction;
        }


        [HttpPost]
        public IActionResult Save([FromBody] PurchaseinvoiceInfo purchaseinvoiceInfo)
        {

           var result= _PurchaseinvoiceAction.Save(purchaseinvoiceInfo);
            return Ok(result);
        }


  

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _PurchaseinvoiceAction.Delete(id);

            return Ok();
        }



        [HttpGet]
        public IActionResult GetPurchaseInvoiceById(int id)
        {
            var item = _PurchaseinvoiceAction.GetPurchaseInvoice(id);
            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetAllPurchaseinvoice()
        {
            var items = _PurchaseinvoiceAction.GetPurchaseinvoiceInfos();
            return Ok(items);
        }


    }
}
