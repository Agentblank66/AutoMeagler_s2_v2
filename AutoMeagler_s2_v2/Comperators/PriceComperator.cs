using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.Comperators
{
    public class PriceComperator : IComparer<Order>
    {
        /// <summary>
        /// Compares two orders by the car's price.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns> It return a int descriping wheter they are a like or not </returns>
        public int Compare(Order x, Order y)
        {
            return x.Car.Price.CompareTo(y.Car.Price);
        }
    }
}
