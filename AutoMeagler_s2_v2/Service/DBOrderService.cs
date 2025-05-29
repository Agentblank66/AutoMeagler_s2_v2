using AutoMeagler_s2_v2.EFDbContext;
using AutoMeagler_s2_v2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMeagler_s2_v2.Service
{
    public class DbOrderService
    {
        /// <summary>
        /// The method to get all orders from the database
        /// </summary>
        /// <returns> A list of orders </returns>
        public async Task<List<T>> GetOrders<T>() where T : Order
        {
            using (var context = new OrderDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        //public async Task<List<OrderBuy>> GetBuyOrders()
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        return await context.BuyOrders.ToListAsync();
        //    }
        //}

        //public async Task<List<OrderLeasing>> GetLeaseOrders()
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        return await context.LeaseOrders.ToListAsync();
        //    }
        //}

        //public async Task<List<OrderSale>> GetSaleOrders()
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        return await context.SaleOrders.ToListAsync();
        //    }
        //}

        /// <summary>
        /// The method to add an order to the database
        /// </summary>
        /// <param name="order"></param>
        /// <returns> Adds an order to the database and saves the changes </returns>
        public async Task AddOrder<T>(T order) where T : Order
        {
            using (var context = new OrderDbContext())
            {
                context.Set<T>().Add(order);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// The method that saves the changes to an order from the database
        /// </summary>
        /// <param name="orders"></param>
        /// <returns> Saves a list of orders in the database and saves the changes </returns>
        public async Task SaveOrder<T>(List<T> orders) where T : Order
        {
            using (var context = new OrderDbContext())
            {
                context.Set<T>().AddRange(orders);
                await context.SaveChangesAsync();
            }
        }
    }
}
