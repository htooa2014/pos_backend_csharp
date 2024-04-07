using DotNet7.PosBackendApi.DbService.DbModels;
using DotNet7.PosBackendApi.Models.Setup.Customer;
using DotNet7.PosBackendApi.Models.Setup.Staff;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNet7.PosBackendApi.Features.Setup.Customer
{
    public class CustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
            var lst = await _context.TblCustomers.ToListAsync();
            return lst.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerCode = x.CustomerCode,
                CustomerName = x.CustomerName,
                MobileNo = x.MobileNo,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                StateCode = x.StateCode,
                TownshipCode = x.TownshipCode,
            }).ToList();
        }


        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var custoemr = await _context.TblCustomers.FirstOrDefaultAsync(item => item.CustomerId == id);

            if (custoemr == null)
            {
                return new CustomerModel();
            }

            return new CustomerModel()
            {
                CustomerCode = custoemr.CustomerCode,
                CustomerName = custoemr.CustomerName,
                MobileNo = custoemr.MobileNo,
                DateOfBirth = custoemr.DateOfBirth,
                Gender = custoemr.Gender,
                StateCode = custoemr.StateCode,
                TownshipCode = custoemr.TownshipCode,
            };

        }


        public async Task<string> CreateCustomer(CustomerModel customer)
        {
            TblCustomer customerTable = new TblCustomer()
            {
                CustomerId = customer.CustomerId,
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                MobileNo = customer.MobileNo,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                StateCode = customer.StateCode,
                TownshipCode = customer.TownshipCode
            };
            _context.TblCustomers.Add(customerTable);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Customer Saving Successful" : "Customer Saving fail";
            return message;

        }

        public async Task<string> UpdateCustomer(int id, CustomerModel _customer)
        {
            var customer = await _context.TblCustomers.FirstOrDefaultAsync(item => item.CustomerId == id);

            if (customer == null)
            {
                return "Customer Not Found";
            }

            customer.CustomerId = id;
            customer.CustomerCode = _customer.CustomerCode;
            customer.CustomerName = _customer.CustomerName;
            customer.MobileNo = _customer.MobileNo;
            customer.DateOfBirth = _customer.DateOfBirth;
            customer.Gender = _customer.Gender;
            customer.StateCode = _customer.StateCode;
            customer.TownshipCode = _customer.TownshipCode;

            int result = _context.SaveChanges();
            string message = result > 0 ? "Customer Updating Successful" : "Customer Updating fail";
            return message;

        }

        public async Task<string> DeleteCustomer(int id)
        {
            var customer = await _context.TblCustomers.FirstOrDefaultAsync(item => item.CustomerId == id);

            if (customer == null)
            {
                return "Customer Not Found";
            }

            _context.Remove(customer);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Customer Deleting Successful" : "Customer Deleting fail";
            return message;

        }
    }
}
