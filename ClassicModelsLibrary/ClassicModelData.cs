using ClassicModelsLibrary.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicModelsLibrary
{
    public static class ClassicModelData
    {
        // siden klassen er static -> må alt være static !!!

        public static List<Customer> GetCustomers(string fileName) 
        {
            List<Customer> customerList = new();
            using (StreamReader reader = new(fileName))
            {
                string? headerLine = reader.ReadLine();
                if (headerLine != null)
                {
                    string? line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] lineSplitValuesByComma = line.Split(",");
                        if (lineSplitValuesByComma.Length == 6)
                        {
                            Customer customer = new();
                            customer.CustomerNumber = int.Parse(lineSplitValuesByComma[0]);
                            customer.CustomerName = lineSplitValuesByComma[1];
                            customer.Phone = lineSplitValuesByComma[2];
                            customer.Address = lineSplitValuesByComma[3];
                            customer.City = lineSplitValuesByComma[4];
                            customer.Country = lineSplitValuesByComma[5];
                            customerList.Add(customer);
                        }
                        else
                        {
                            Console.WriteLine($"BAD INPUT: {line}");
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            return customerList;
        }

        public static List<Employee> GetEmployees(string fileName)
        {
            List<Employee> employeeList = new();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines.Skip(1))
            {
                string[] employeeArr = line.Split(",");
                // employeeNumber,firstName,lastName,email,sdfa,asdf,4556,e,jobTitle
                // "List Pattern Matching" // underscore -> hva som helst
                //https://thecodeblogger.com/2022/09/19/c-11-introducing-list-patterns-matching/
                if (employeeArr is [var employeeNrStr ,var firstName ,var lastName ,var email, var jobTitle] )
                {
                    int employeeNr;
                    if (!int.TryParse(employeeNrStr, out employeeNr))
                        Console.WriteLine("Error parsing int");
                    Employee employee = new()
                    {
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        EmployeeNumber = employeeNr,
                        JobTitle = jobTitle
                    };
                    employeeList.Add(employee);
                }
                else
                    Console.WriteLine("Bad input");

               Console.WriteLine(line);
            }

            return employeeList;
        }

        public static List<Payment> GetPayments(string fileName)
        {
            List<Payment> paymentList = new();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines.Skip(1))
            {
                string[] paymentArr = line.Split(",");

                // customerNumber,checkNumber,paymentDate,amount
                // 103,HQ336336,2004-10-19,6066.78
                if (paymentArr is [var customerIdStr , var checkNrStr , var paymentDateStr, var amountStr])
                {
                    if (!int.TryParse(customerIdStr, out int customerNr))
                        Console.WriteLine("Error parsing int");

                    // amount -> double (6066.78 -> double)
                    // 3.14 engelsk 
                    // 3,14 norsk
                    double.TryParse(amountStr, CultureInfo.InvariantCulture, out double amount);

                    /*
                     * 2004-10-19
                     * yyyy-MM-dd
                     * 
                        yyyy : Årstallet, for eksempel "2022".
		                MM : Måneden, representert med to sifre, for eksempel "03" for mars.
		                dd : Dagen i måneden, representert med to sifre, for eksempel "14".
		                HH : Timen, i 24-timers format, representert med to sifre, for eksempel "08".
		                mm : Minuttene, representert med to sifre, for eksempel "30".
		                ss : Sekundene, representert med to sifre, for eksempel "45".
                        fff : Millisekundene, representert med tre sifre, for eksempel "789".
                     */
                    DateTime.TryParseExact(paymentDateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime paymentDate);
                    Payment payment = new()
                    {
                        Amount = amount,
                        CheckNumber = checkNrStr,
                        CustomerId = customerNr,
                        PaymentDate = paymentDate
                    };
                    paymentList.Add(payment);
                }
                else
                    Console.WriteLine("Bad input");

                Console.WriteLine(line);
            }

            return paymentList;
        }

    }
}
