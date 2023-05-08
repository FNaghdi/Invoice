using Business.DTOs;
using Business.Services;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [ApiController]

    [Route("[controller]/[action]")]
    public class ProductControler:ControllerBase
    {



        private readonly ILogger<ProductControler> _logger;
        private readonly IProductAction _productAction;
        private readonly IPersonAction _personAction;
        public ProductControler(ILogger<ProductControler> logger, IProductAction productAction)
        {
            _logger = logger;
           
            _productAction = productAction;
        }


        [HttpPost]
        public IActionResult Save( [FromBody] ProductModel product)
        {
           
            _productAction.Save(product);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update( [FromBody] Product product1)
        {
            _productAction.Update(product1);
          
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete( int idp)
        {
            _productAction.Delete(idp);
           
            return Ok();
        }


    }
}
