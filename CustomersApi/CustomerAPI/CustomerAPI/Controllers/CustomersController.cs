using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getallcustomers")]
        public IActionResult GetAllCustomer()
        {
            var result = _customerService.GetAllCustomerWithAddress();
            return result.Success ? Ok(result) : BadRequest();

        }
        [HttpGet("getcustomerbyid")]
        public IActionResult GetCustomerById(Guid customerId)
        {
            var result = _customerService.GetCustomerByIdWithAddress(customerId);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("validate")]
        public IActionResult Validate(Guid customerId)
        {
            var result = _customerService.Validate(customerId);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("create")]
        public IActionResult Create(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            var result = _customerService.Create(customer);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid customerId)
        {
            var result = _customerService.Delete(customerId);
            return result.Success ? Ok(result) : BadRequest();
        }
    }
}
