using AutoMeagler_s2_v2.MockData;
using AutoMeagler_s2_v2.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoMeagler_s2_v2.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// A public list of customers and employees.
        /// </summary>
        public List<Customer> Customers { get; set; } 
        public List<Employee> Employees { get; set; }
        public User.UserType UserType { get; set; }
        private DbUserService _dbUserService;

        /// <summary>
        /// A constructor which initializes the list of customers and employees.
        /// </summary>


        public UserService(DbUserService dbUserService)
        {
            _dbUserService = dbUserService;

            Customers = _dbUserService.GetCustomers().Result.ToList();
            Employees = _dbUserService.GetEmployees().Result.ToList();
            
            //_dbUserService.SaveUsers(Employees.Cast<User>().ToList()).Wait();
            
        }

        /// <summary>
        /// A method which adds a user to the list of customers or employees.
        /// </summary>
        /// <param name="customer"></param>
        public void AddUser<T>(T user) where T : User
        {
            if (typeof(T) == typeof(Customer))
            {
                if (user is Customer customer)
                {
                    Customers.Add(customer);
                }
            }
            else if (typeof(T) == typeof(Employee))
            {
                if (user is Employee employee)
                {
                    Employees.Add(employee);
                }
            }
            _dbUserService.AddUser(user);
        }

        /// <summary>
        /// A method which deletes a user from the list of customers or employees.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        public void DeleteUser<T>(T user) where T : User
        {
            if (typeof(T) == typeof(Customer))
            {
                Customers.Remove(user as Customer);
            }
            else if (typeof(T) == typeof(Employee))
            {
                Employees.Remove(user as Employee);
            }
            _dbUserService.DeleteUser(user);
        }

        /// <summary>
        /// A method which gets a user from the list of customers or employees by id and type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public User GetUser(int id, User.UserType? user)
        {
            switch (user)
            {
                case User.UserType.Employee:
                    foreach (Employee employee in Employees)
                    {
                        if (employee.Id == id)
                        {
                            return employee;
                        }
                    }
                    break;
                case User.UserType.Customer:
                    foreach (Customer customer in Customers)
                    {
                        if (customer.Id == id)
                        {
                            return customer;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid user type");
            }
            return null;

        }

        /// <summary>
        /// A method which updates a user in the list of customers or employees.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            User userToUpdate = GetUser(user.Id, user.UserTypes);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                if (user is Employee updatedEmployee && userToUpdate is Employee existingEmployee)
                {
                    
                    updatedEmployee.Type = existingEmployee.Type;
                }
                else if (user is Customer updatedCustomer && userToUpdate is Customer existingCustomer)
                {
                    
                    existingCustomer.WishToSell = updatedCustomer.WishToSell;
                    existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
                }
            }
            _dbUserService.UpdateUser(user);
        }


        /// <summary>
        /// A method which searches for a user in the list of customers or employees by name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<User> SearchbyName(string name) 
        {
            
            List<User> results = new();

            results.AddRange(Customers.Where(customer =>
                customer.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)));

            results.AddRange(Employees.Where(employee =>
                employee.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)));

            return results;
        }
       


        /// <summary>
        /// A method which searches for a user in the list of customers or employees by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// A list of users which contains the customers and employees which contain the name.
        /// </returns>
        //public List<User> SearchByName(string name)
        //{
        //    List<User> results = new();

        //    var customerResult = from Customer in Customers 
        //                         where Customer.FullName.Contains(name, StringComparison.OrdinalIgnoreCase) select Customer;
        //    var employeeResult = from Employee in Employees 
        //                         where Employee.FullName.Contains(name, StringComparison.OrdinalIgnoreCase) select Employee;

        //    results.AddRange(customerResult);
        //    results.AddRange(employeeResult);

        //    return results;
        //}

    }
}
