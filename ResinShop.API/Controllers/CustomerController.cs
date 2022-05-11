using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.API.Models;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;


namespace ResinShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var response = _customerRepository.GetAll();

            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var response = _customerRepository.Get(id);

            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer c = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    StreetAddress = customer.StreetAddress,
                    City = customer.City,
                    StateName = customer.StateName,
                    ZipCode = customer.ZipCode,
                    PhoneNumber = customer.PhoneNumber
                };

                var response = _customerRepository.Insert(c);

                if (response.Success)
                {
                    return CreatedAtRoute(nameof(GetCustomer), new { id = c.CustomerId }, c);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult EditCustomer(CustomerModel customerModel)
        {
            if (ModelState.IsValid && customerModel.CustomerId > 0)
            {
                Customer customer = new Customer
                {
                    CustomerId = customerModel.CustomerId,
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.LastName,
                    Email = customerModel.Email,
                    StreetAddress = customerModel.StreetAddress,
                    City = customerModel.City,
                    StateName = customerModel.StateName,
                    ZipCode = customerModel.ZipCode,
                    PhoneNumber = customerModel.PhoneNumber
                };

                if (!_customerRepository.Get(customer.CustomerId).Success)
                {
                    return NotFound($"Customer {customer.CustomerId} not found.");
                }

                var response = _customerRepository.Update(customer);

                if (response.Success)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            else
            {
                if (customerModel.CustomerId < 1)
                {
                    ModelState.AddModelError("customerId", "Invalid Customer ID");
                }
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_customerRepository.Get(id).Success)
            {
                return NotFound($"Customer {id} not found.");
            }

            var response = _customerRepository.Delete(id);

            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
