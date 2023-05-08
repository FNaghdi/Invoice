using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Business.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Authorize]

    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private readonly IProductAction _productAction;
        private readonly IPersonAction _personAction;
        public PersonController(ILogger<PersonController> logger, IPersonAction personAction)
        {
            _logger = logger;
            _personAction = personAction;
         
        }


        [HttpPost]
        public IActionResult Save([FromBody] PersonModel person )
        {
            _personAction.Save(person);
           
            return Ok();
        }


        [HttpPut]
        public IActionResult Update([FromBody] Person person )
        {
         
            _personAction.Update(person);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id )
        {
          
            _personAction.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPersonById(int id)
        {
            var person = _personAction.GetPersonById(id);
            return Ok(person);
        }

        [HttpGet]
        public IActionResult GetAllPerson()
        {
            var persons = _personAction.GetPeople();
            return Ok(persons);
        }


    }
}