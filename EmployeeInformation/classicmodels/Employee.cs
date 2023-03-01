using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// employeeNumber,firstName,lastName,email,jobTitle

namespace EmployeeInformation.classicmodels
{
    internal class Employee
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;

        public override string ToString()
        {
            // her velger du hva som skal ut av denne metoden - hva er fornuftig informasjon her?
            return $"EmployeeNr:{EmployeeNumber}, FirstName:{FirstName}, LastName:{LastName}, Email:{Email}, JobTitle:{JobTitle}";
        }

    
    }

}
