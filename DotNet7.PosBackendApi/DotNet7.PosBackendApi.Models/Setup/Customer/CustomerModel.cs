using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet7.PosBackendApi.Models.Setup.Customer
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string MobileNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string StateCode { get; set; }

        public string TownshipCode { get; set; }

    }
}
