using AutoMeagler_s2_v2.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoMeagler_s2_v2.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        /// <summary>
        /// A privat static list of employees.
        /// </summary>
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee(1, "Oliver", "Kronborg", "Sælger", "Okronborg@gmail.com", passwordHasher.HashPassword(null, "123"))
        };

        /// <summary>
        /// A privat static list of customers.
        /// </summary>
        private static List<Customer> Customers = new List<Customer>
        {
            new Customer(101, "Lars", "Larsen", 12456790, "LLarsen@gmail.com", passwordHasher.HashPassword(null, "123"), true)
            
        };

        /// <summary>
        /// A method which returns a list of employees.
        /// </summary>
        /// <returns>
        /// Returns a list of employees.
        /// </returns>
        public static List<Employee> GetMockEmployees()
        {
            return Employees;
        }

        /// <summary>
        /// A method which returns a list of customers.
        /// </summary>
        /// <returns>
        /// Returns a list of customers.
        /// </returns>
        public static List<Customer> GetMockCustomers()
        {
            return Customers;
        }
    }
}
