using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.MockData
{
    public class MockOrders
    {
        private static List<Order> _orders = new List<Order>()
       {
           new OrderLeasing(1,MockCars.GetMockCars()[0], MockUsers.GetMockEmployees()[0], MockUsers.GetMockCustomers()[0], Order.OrderType.Leasing, 30000, 2025, 2025, 01, 04, 01, 04, 2400),
           new OrderBuy(3, MockCars.GetMockCars()[0], MockUsers.GetMockEmployees()[0], MockUsers.GetMockCustomers()[0], Order.OrderType.Buy, 40000, 2025, 01, 01),
           new OrderSale(9, MockCars.GetMockCars()[0], MockUsers.GetMockEmployees()[0], MockUsers.GetMockCustomers()[0], Order.OrderType.Sale, 50000, 2025, 01, 01)
       };

        public static List<Order> GetMockOrders()
        {
            return _orders;
        }
    }
}
