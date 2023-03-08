using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicModelsLibrary.model
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(int customerNumber, string customerName, string phone, string address, string city, string country)
        {
            CustomerNumber = customerNumber;
            CustomerName = customerName;
            Phone = phone;
            Address = address;
            City = city;
            Country = country;
        }

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

    public class Class1
    {
    }
}
