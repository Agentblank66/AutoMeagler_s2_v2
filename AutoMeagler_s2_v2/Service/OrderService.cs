using AutoMeagler_s2_v2.MockData;
using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using AutoMeagler_s2_v2.Comperators;

namespace AutoMeagler_s2_v2.Service
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Private lists for the OrderService class.
        /// </summary>
        public List<Order> _orders { get; set; }
        public List<OrderBuy> _orderBuys { get; set; }
        public List<OrderLeasing> _orderLeasings { get; set; }
        public List<OrderSale> _orderSales { get; set; }
        public DbOrderService _dbOrderService { get; set; }

        /// <summary>
        /// Constructor for the OrderService class.
        /// </summary>
        public OrderService(DbOrderService dbOrderService)
        {
            _dbOrderService = dbOrderService;
            _orders = MockOrders.GetMockOrders();
            //_orders = _dbOrderService.GetOrders<Order>().Result;
            _dbOrderService.SaveOrder(_orders);
        }

        public OrderService() 
        {
            _orders = MockOrders.GetMockOrders();
        }

        /// <summary>
        /// A method that gets all orders.
        /// </summary>
        /// <returns> All orders </returns>
        public List<Order> GetOrders()
        {
            return _orders;

        }

        /// <summary>
        /// A method that adds an order to the list of orders.
        /// </summary>
        /// <param name="order"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddOrder<T>(T order) where T : Order
        {
            _orders.Add(order);
            _dbOrderService?.AddOrder(order);

            switch (order)
            {
                case OrderLeasing leasing:
                    _orderLeasings.Add(leasing);
                    break;
                case OrderBuy buy:
                    _orderBuys.Add(buy);
                    break;
                case OrderSale sale:
                    _orderSales.Add(sale);
                    break;
                default:
                    throw new ArgumentException("Ugyldig order type", nameof(order));
            }
        }
        //public void AddOrder(Order order)
        //{
        //    int orderType = (int)order.Type;
        //    switch (orderType)
        //    {
        //        case 0:
        //            _orderLeasings.Add((OrderLeasing)order);
        //            _orders.Add(order);
        //            break;
        //        case 1:
        //            _orderBuys.Add((OrderBuy)order);
        //            _orders.Add(order);
        //            break;
        //        case 2:
        //            _orderSales.Add((OrderSale)order);
        //            _orders.Add(order);
        //            break;
        //        default:
        //            throw new ArgumentException("Ugyldig order type");
        //    }
        //}

        /// <summary>
        /// A method that gets an order by id and type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns> A specific order </returns>
        /// <exception cref="ArgumentException"></exception>
        public Order GetOrder(int id, Order.OrderType type)
        {
            return type switch
            {
                Order.OrderType.Leasing => GetOrderById(_orderLeasings, id),
                Order.OrderType.Buy => GetOrderById(_orderBuys, id),
                Order.OrderType.Sale => GetOrderById(_orderSales, id),
                _ => throw new ArgumentException("Invalid order type", nameof(type))
            };
        }

        //public Order GetOrder(int id, Order.OrderType type)
        //{
        //    switch (type)
        //    {
        //        case Order.OrderType.Leasing:
        //            foreach (OrderLeasing order in _orderLeasings)
        //            {
        //                if (order.Id == id)
        //                {
        //                    return order;
        //                }
        //            }
        //            break;
        //        case Order.OrderType.Buy:
        //            foreach (OrderBuy order in _orderBuys)
        //            {
        //                if (order.Id == id)
        //                {
        //                    return order;
        //                }
        //            }
        //            break;
        //        case Order.OrderType.Sale:
        //            foreach (OrderSale order in _orderSales)
        //            {
        //                if (order.Id == id)
        //                {
        //                    return order;
        //                }
        //            }
        //            break;
        //        default:
        //            throw new ArgumentException("Invalid order type");
        //    }
        //    return null;

        //}


        /// <summary>
        /// A method that updates an order.
        /// </summary>
        /// <param name="order"></param>
        /// 
        public void UpdateOrder<T>(T order) where T : Order
        {
            var existingOrder = GetOrder(order.Id,order.Type);
            if (existingOrder == null)
                return;

            // Update common fields
            existingOrder.Car = order.Car;
            existingOrder.Employee = order.Employee;
            existingOrder.Customer = order.Customer;

            // Update type-specific fields
            switch (order)
            {
                case OrderLeasing leasingOrder when existingOrder is OrderLeasing leasingToUpdate:
                    leasingToUpdate.Depositum = leasingOrder.Depositum;
                    leasingToUpdate.LeasingDateStart = leasingOrder.LeasingDateStart;
                    leasingOrder.LeasingDateEnd = leasingOrder.LeasingDateEnd;
                    leasingToUpdate.MonthlyPayment = leasingOrder.MonthlyPayment;
                    break;

                case OrderBuy buyOrder when existingOrder is OrderBuy buyToUpdate:
                    buyToUpdate.BuyPrice = buyOrder.BuyPrice;
                    buyToUpdate.BuyDate = buyOrder.BuyDate;
                    break;

                case OrderSale saleOrder when existingOrder is OrderSale saleToUpdate:
                    saleToUpdate.SalePrice = saleOrder.SalePrice;
                    saleToUpdate.SaleDate = saleOrder.SaleDate;
                    break;

                default:
                    throw new ArgumentException("Unsupported order type", nameof(order));
            }
            _dbOrderService?.SaveOrder(_orders);
        }

        //public void UpdateOrder(Order order)
        //{
        //    Order orderToUpdate = GetOrder(order.Id, order.Type);
        //    if (orderToUpdate != null)
        //    {
        //        orderToUpdate.Car = order.Car;
        //        orderToUpdate.Employee = order.Employee;
        //        orderToUpdate.Customer = order.Customer;

        //        if (order is OrderLeasing)
        //        {
        //            OrderLeasing leasingOrder = (OrderLeasing)order;
        //            ((OrderLeasing)orderToUpdate).Depositum = leasingOrder.Depositum;
        //            ((OrderLeasing)orderToUpdate).LeasingDateStart = leasingOrder.LeasingDateStart;
        //        }
        //        else if (order is OrderBuy)
        //        {
        //            OrderBuy buyOrder = (OrderBuy)order;
        //            ((OrderBuy)orderToUpdate).BuyPrice = buyOrder.BuyPrice;
        //            ((OrderBuy)orderToUpdate).BuyDate = buyOrder.BuyDate;
        //        }
        //        else if (order is OrderSale)
        //        {
        //            OrderSale saleOrder = (OrderSale)order;
        //            ((OrderSale)orderToUpdate).SalePrice = saleOrder.SalePrice;
        //            ((OrderSale)orderToUpdate).SaleDate = saleOrder.SaleDate;
        //        }
        //    }
        //}

        /// <summary>
        /// A method that deletes an order if it exists.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns> Either the deleted order or null </returns>
        /// <exception cref="ArgumentException"></exception>
        /// 
        public T DeleteOrder<T>(int id, Order.OrderType type) where T : Order
        {
            var orderToDeleted = GetOrder(id, type);
            if (orderToDeleted == null)
                return null;
            switch (orderToDeleted.Type)
            {
                case Order.OrderType.Leasing:
                    _orderLeasings.Remove((OrderLeasing)orderToDeleted);
                    break;
                case Order.OrderType.Buy:
                    _orderBuys.Remove((OrderBuy)orderToDeleted);
                    break;
                case Order.OrderType.Sale:
                    _orderSales.Remove((OrderSale)orderToDeleted);
                    break;
                default:
                    throw new ArgumentException("Invalid order type", nameof(type));
            }
            _orders.Remove(orderToDeleted);
            _dbOrderService?.SaveOrder(_orders);

            return (T)orderToDeleted;
        }

        //public Order DeleteOrder(int id, Order.OrderType type) 
        //{
        //    Order tempOrderToBeDeleted = GetOrder(id, type);
        //    if (tempOrderToBeDeleted != null) 
        //    {
        //        switch (tempOrderToBeDeleted.Type)
        //        {
        //            case Order.OrderType.Leasing:
        //                _orderLeasings.Remove((OrderLeasing)tempOrderToBeDeleted);
        //                break;
        //            case Order.OrderType.Buy:
        //                _orderBuys.Remove((OrderBuy)tempOrderToBeDeleted);
        //                break;
        //            case Order.OrderType.Sale:
        //                _orderSales.Remove((OrderSale)tempOrderToBeDeleted);
        //                break;
        //            default:
        //                throw new ArgumentException("Invalid order type");
        //        }
        //        return tempOrderToBeDeleted;
        //    }
        //    return null;
        //}

        /// <summary>
        /// A method that searches for orders by customer name.
        /// </summary>
        /// <param name="str"></param>
        /// <returns> A list of orders </returns>
        public IEnumerable<T> NameSearch<T>(string str) where T : Order
        {
            if (string.IsNullOrEmpty(str))
                return Enumerable.Empty<T>();

            var result = _orders.OfType<T>().Where(order => order.Customer.FullName.Contains(str, StringComparison.OrdinalIgnoreCase));

            return result;
        }

        /// <summary>
        /// A method that filters orders by price and monthly payment.
        /// </summary>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <param name="minMonthlyPayment"></param>
        /// <param name="maxMonthlyPayment"></param>
        /// <returns> A list of orders </returns>
        public IEnumerable<Order> PriceFilter(double minPrice, double maxPrice, double minMonthlyPayment, double maxMonthlyPayment)
        {
            List<Order> result = new List<Order>();
            foreach (OrderLeasing order in _orderLeasings)
            {
                if (order.MonthlyPayment >= minMonthlyPayment && order.MonthlyPayment <= maxMonthlyPayment)
                {
                    result.Add(order);
                }
            }
            foreach (OrderBuy order in _orderBuys)
            {
                if (order.BuyPrice >= minPrice && order.BuyPrice <= maxPrice)
                {
                    result.Add(order);
                }
            }
            foreach (OrderSale order in _orderSales)
            {
                if (order.SalePrice >= minPrice && order.SalePrice <= maxPrice)
                {
                    result.Add(order);
                }
            }
            return result;
        }

        /// <summary>
        /// A methods that sorts orders by id by using generics to do so.
        /// </summary>
        /// <returns> A list where all the orders are sorted </returns>
        public IEnumerable<T> SortById<T>() where T : Order
        {
            return _orders.OfType<T>().OrderBy(order => order.Id).ToList();
        }

        /// <summary>
        /// A method that sorts orders by id by using LINQ to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> All orders in numerical order by Id </returns>
        //public IEnumerable<T> SortByIdByLINQ<T>(IEnumerable<T> orders) where T : Order
        //{
        //    return from order in orders
        //           orderby order.Id
        //           select order;
        //}

        /// <summary>
        /// A method that sorts orders by id in descending order by using generics to do so.
        /// </summary>
        /// <returns> A list with the newly sorted orders </returns>
        public IEnumerable<T> SortByIdDecending<T>() where T : Order
        {
            return _orders.OfType<T>().OrderByDescending(order => order.Id).ToList();
        }

        /// <summary>
        /// A method that sorts orders by id in descending order by using LINQ and generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list with newly sorted orders in decending order </returns>
        //public IEnumerable<T> SortByIdDescendingByLINQ<T>(IEnumerable<T> orders) where T : Order
        //{
        //    return from order in orders
        //           orderby order.Id descending
        //           select order;
        //}

        /// <summary>
        /// A method that sorts orders by customer name by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list with the sorted orders by name </returns>
        public IEnumerable<T> SortByName<T>(IEnumerable<T> orders) where T: Order
        {
            return orders.OrderBy(order => order.Customer.FullName).ToList();
        }

        /// <summary>
        /// A method that sorts orders by customer name in descending order by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list with the sorted orders by name in descending order </returns>
        public IEnumerable<T> SortByNameDecending<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderByDescending(order => order.Customer.FullName).ToList();
        }

        /// <summary>
        /// A method that sorts orders by price by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list where all orders are sorted by price </returns>
        public IEnumerable<T> SortByPrice<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderBy(order => order.Car.Price).ToList();
        }

        /// <summary>
        /// A method that sorts orders by price in descending order by using generics to do so.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <returns> A list where all orders are sorted by price in descending order </returns>
        public IEnumerable<T> SortByPriceDescending<T>(IEnumerable<T> orders) where T : Order
        {
            return orders.OrderByDescending(order => order.Car.Price).ToList();
        }

        /*---------------------------------- Helper Methods -------------------------------------------*/
        /// <summary>
        /// This is a helper method that gets an order by id for the GetOrder method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders"></param>
        /// <param name="id"></param>
        /// <returns> The first order that has a matching Id. </returns>
        private T GetOrderById<T>(List<T> orders, int id) where T : Order
        {
            if (orders == null) return null;
            return orders.FirstOrDefault(order => order.Id == id);
        }
    }
}
