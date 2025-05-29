using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// Methods that any class implementing this interface must implement.
        /// </summary>
        List<Order> GetOrders();
        void AddOrder<T>(T order) where T : Order;
        void UpdateOrder<T>(T order) where T : Order;
        Order GetOrder(int id, Order.OrderType type);
        T DeleteOrder<T>(int id, Order.OrderType type) where T : Order;
        IEnumerable<T> NameSearch<T>(string str) where T : Order;
        IEnumerable<Order> PriceFilter(double minPrice, double maxPrice, double minLeasing, double maxLeasing);
        IEnumerable<T> SortById<T>() where T : Order;
        IEnumerable<T> SortByIdDecending<T>() where T : Order;
        IEnumerable<T> SortByName<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByNameDecending<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByPrice<T>(IEnumerable<T> orders) where T : Order;
        IEnumerable<T> SortByPriceDescending<T>(IEnumerable<T> orders) where T : Order;

    }
}
