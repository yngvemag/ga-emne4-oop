using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInformation.classicmodels
{
    // CustomerNumber,CustomerName,Phone,Address,City,Country
    internal class Customer
    {
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"CustomerNr: {CustomerNumber}, CustomerName={CustomerName}, Phone={Phone}, Address={Address}" +
                $"City={City}, Country={Country}";

        }
    }
}
