using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMeagler_s2_v2.Service;
using AutoMeagler_s2_v2.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutoMeagler_s2_v2.Pages.Order
{
    //[Authorize(Roles = "Employee")]
    public class DeleteOrderModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        private IOrderService _orderService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService"></param>
        public DeleteOrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The orders to be shown
        /// </summary>
        [BindProperty]
        public Models.Order Order { get; set; }

        /// <summary>
        /// The search string for the orders
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderType"></param>
        /// <returns> Redirects to error page or current page </returns>
        public IActionResult OnGet(int id, Models.Order.OrderType orderType)
        {
            Order = _orderService.GetOrder(id, orderType);
            if (Order == null)
                return RedirectToPage("/NotFound");
            
            return Page();
        }

        /// <summary>
        /// A method which is called when the page is posted, where it deletes an order.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderType"></param>
        /// <returns> Redirects to error page or wanted page </returns>
        public IActionResult OnPost(int id, Models.Order.OrderType orderType)
        {
            Models.Order order = _orderService.DeleteOrder<Models.Order>(id, orderType);
            if (order == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("GetAllOrders");
        }
    }
}
