using DotNet7.PosBackendApi.Features.Setup.Staff;
using DotNet7.PosBackendApi.Models.Setup.Customer;
using DotNet7.PosBackendApi.Models.Setup.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7.PosBackendApi.Features.Setup.Customer
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return Ok(await _customerService.GetCustomers());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                CustomerModel customer = new CustomerModel();
                customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound("Customer not found.");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerModel customer)
        {
            try
            {

                return Ok(await _customerService.CreateCustomer(customer));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateState(int id, CustomerModel customer)
        {
            try
            {

                return Ok(await _customerService.UpdateCustomer(id, customer));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {

            try
            {

                return Ok(await _customerService.DeleteCustomer(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            };
        }




    }
}
