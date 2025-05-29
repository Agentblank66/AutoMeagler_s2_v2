using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.Comperators
{
    public class NameComperator : IComparer<Order>
    {
        /// <summary>
        /// Compares two orders by the customer's full name.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns> It return a int descriping wheter they are a like or not </returns>
        public int Compare(Order x, Order y)
        {
            return x.Customer.FullName.CompareTo(y.Customer.FullName);
        }
    }
}
