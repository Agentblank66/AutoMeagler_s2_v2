using AutoMeagler_s2_v2.Models;
using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoMeagler_s2_v2.Pages.Order
{
    public class CreateOrderSaleModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        public IOrderService _orderService;

        /// <summary>
        /// The orders that is to be created
        /// </summary>
        [BindProperty]
        public OrderSale OrderSale { get; set; }

        public CreateOrderSaleModel(IOrderService orderService)
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
            OrderSale.SaleDate = new DateTime(OrderSale.Year, OrderSale.Month, OrderSale.Day);
            _orderService.AddOrder(OrderSale);
            return RedirectToPage("/Order/GetAllOrders");
        }
    }
}
