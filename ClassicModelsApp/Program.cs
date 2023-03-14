using ClassicModelsLibrary;
using ClassicModelsLibrary.model;
using System.Reflection;

// hvordan ville dere brukt den?
// enkel å bruke -> 
// List<Customer> customer = ClassicModelData.GetCustomers(fileName);

string customerFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Customers.csv";
string employeeFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Employees.csv";
string paymentFile = "C:\\ga\\Emne 4 OOP Introduksjon\\Payments.csv";



var customerList = ClassicModelData.GetCustomers(customerFile);
var employeeList = ClassicModelData.GetEmployees(employeeFile);
var paymentList = ClassicModelData.GetPayments(paymentFile);

foreach (var c in customerList)
    Console.WriteLine(c.ToString());
employeeList.ForEach(emp => Console.WriteLine(emp.ToString()));
paymentList.ForEach(payment => Console.WriteLine(payment.ToString()));

