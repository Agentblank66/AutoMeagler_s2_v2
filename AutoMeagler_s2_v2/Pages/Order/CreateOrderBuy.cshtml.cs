using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoMeagler_s2_v2.Pages.Order
{
    public class CreateOrderBuyModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        public IOrderService _orderService;
        //public ICarService _carService;

        /// <summary>
        /// The orders that is to be created
        /// </summary>
        [BindProperty]
        public OrderBuy OrderBuy { get; set; }
        //public List<Car> SelectCar { get; set; }

        public CreateOrderBuyModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Initializes the page with the available order types for selection.
        /// </summary>
        /// <returns> The currect page </returns>
        public IActionResult OnGet()
        {
            //SelectCar = _carService.GetCars();
            return Page();
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OrderBuy.BuyDate = new DateTime(OrderBuy.Year, OrderBuy.Month, OrderBuy.Day);
            _orderService.AddOrder(OrderBuy);
            return RedirectToPage("/Order/GetAllOrders");
        }

    }
}