using AutoMeagler_s2_v2.EFDbContext;
using AutoMeagler_s2_v2.Models;
using Microsoft.EntityFrameworkCore;
using static AutoMeagler_s2_v2.Models.User;

namespace AutoMeagler_s2_v2.Service
{
    public class DbUserService
    {
        private readonly UserDbContext _userDbContext;

        public DbUserService(UserDbContext context)
        {
            _userDbContext = context;
        }
        public async Task<List<Customer>> GetCustomers()
        {
                
              return await _userDbContext.Customers.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployees()
        {

            return await _userDbContext.Employees.ToListAsync();
        }

        public async Task AddUser(User user)
        {
                if(user is Customer customer)
                {
                    _userDbContext.Customers.Add(customer);
                }
                else if (user is Employee employee)
                {
                    _userDbContext.Employees.Add(employee);
                }
                else
                {
                    throw new ArgumentException("Invalid user type");
                }
                _userDbContext.SaveChanges();
        }

        public async Task SaveUsers(List<User> users)
        {
                foreach (var user in users)
                {
                    if (user is Customer customer)
                    {
                        _userDbContext.Customers.Add(customer);
                    }
                    else if (user is Employee employee)
                    {
                        _userDbContext.Employees.Add(employee);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid user type");
                    }
                }
                await _userDbContext.SaveChangesAsync(); 
        }

        public async Task DeleteUser(User user)
        {
                if(user is Customer customer)
                {
                    _userDbContext.Customers.Remove(customer);
                }
                else if (user is Employee employee)
                {
                    _userDbContext.Employees.Remove(employee);
                }
                else
                {
                    throw new ArgumentException("No users found");
                }
                _userDbContext.SaveChanges();
        }

        //public async Task UpdateUser(User user)
        //{


        //        if (user is Customer customer)
        //        {
        //            _context.Customers.Update(customer);
        //        }
        //        else if (user is Employee employee)
        //        {
        //            _context.Employees.Update(employee);
        //        }
        //        else
        //        {
        //            throw new ArgumentException("No users found");
        //        }
        //        _context.SaveChanges();

        //}

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task UpdateUser(User user)
        {
            if (user is Customer customer)
            {
                var existing = await _userDbContext.Customers.FindAsync(customer.Id);
                if (existing != null)
                {
                    _userDbContext.Entry(existing).CurrentValues.SetValues(customer);
                    await _userDbContext.SaveChangesAsync();
                }
            }
            else if (user is Employee employee)
            {
                var existing = await _userDbContext.Employees.FindAsync(employee.Id);
                if (existing != null)
                {
                    _userDbContext.Entry(existing).CurrentValues.SetValues(employee);
                    await _userDbContext.SaveChangesAsync();
                }
            }
            else
            {
                throw new ArgumentException("No users found");
            }
        }

    }
}
