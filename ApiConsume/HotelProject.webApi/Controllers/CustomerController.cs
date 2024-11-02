using HotelProject.BusunessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _customerService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.TInsert(customer);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var values = _customerService.TGetById(id);
            _customerService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.TUpdate(customer);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var values = _customerService.TGetById(id);
            return Ok(values);
        }
    }
}
