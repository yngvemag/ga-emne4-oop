using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
 employeeNumber,firstName,lastName,email,jobTitle
1002,Diane,Murphy,dmurphy@classicmodelcars.com,President
 */


namespace ClassicModelsLibrary.model
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"EmployeeNr:{EmployeeNumber}, FirstName:{FirstName}, " +
                $"LastName:{LastName}, Email:{Email}, JobTitle:{JobTitle}";
        }
    }
}
