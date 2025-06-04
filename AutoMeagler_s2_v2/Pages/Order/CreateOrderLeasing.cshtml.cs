using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Order
{
    public class CreateOrderLeasingModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        public IOrderService _orderService;

        [BindProperty]
        public OrderLeasing OrderLeasing { get; set; }

        public CreateOrderLeasingModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OrderLeasing.LeasingDateStart = new DateTime(OrderLeasing.StartYear, OrderLeasing.StartMonth, OrderLeasing.StartDay);
            OrderLeasing.LeasingDateEnd = new DateTime(OrderLeasing.EndYear, OrderLeasing.EndMonth, OrderLeasing.EndDay);
            _orderService.AddOrder(OrderLeasing);
            return RedirectToPage("/Order/GetAllOrders");

        }
    }
}
