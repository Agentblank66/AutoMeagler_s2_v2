using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMeagler_s2_v2.Service;

namespace AutoMeagler_s2_v2.Pages.Order
{
    public class GetAllOrdersModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        private IOrderService _orderService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService"></param>
        public GetAllOrdersModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The orders to be shown
        /// </summary>
        public List<Models.Order>? Orders { get; set; }

        /// <summary>
        /// The search string for the orders
        /// </summary>
        [BindProperty]
        public string SearchString { get; set; }

        /// <summary>
        /// The minimum price for the orders
        /// </summary>
        [BindProperty]
        public double MinPrice { get; set; }

        /// <summary>
        /// The maximum price for the orders
        /// </summary>
        [BindProperty]
        public double MaxPrice { get; set; }

        /// <summary>
        /// The minimum leasing for the orders
        /// </summary>
        [BindProperty]
        public double MinLeasing { get; set; }

        /// <summary>
        /// The maximum leasing for the orders
        /// </summary>
        [BindProperty]
        public double MaxLeasing { get; set; }

        /// <summary>
        /// Searches for orders by customer name
        /// </summary>
        /// <returns> To the same newly updated page </returns>
        public IActionResult OnPostNameSearch()
        {
            Orders = _orderService.NameSearch<Models.Order>(SearchString).ToList();
            return Page();
        }

        /// <summary>
        /// Filters the price of the orders
        /// </summary>
        /// <returns> To the same newly updated page </returns>
        public IActionResult OnPostPriceFilter()
        {
            Orders = _orderService.PriceFilter(MinPrice, MaxPrice, MinLeasing, MaxLeasing).ToList();
            return Page();
        }

        /// <summary>
        /// Sorts the orders by ID
        /// </summary>
        /// <returns> Rerenders the page </returns>
        public IActionResult OnGetSortById()
        {
            Orders = _orderService.SortById<Models.Order>().ToList();
            return Page();
        }

        /// <summary>
        /// Sorts the orders by ID in descending order
        /// </summary>
        /// <returns> Rerenders the page </returns>
        public IActionResult OnGetSortByIdDescending()
        {
            Orders = _orderService.SortByIdDecending<Models.Order>().ToList();
            return Page();
        }

        /// <summary>
        /// Sorts the orders by name
        /// </summary>
        /// <returns> Rerenders the page </returns>
        public IActionResult OnGetSortByName()
        {
            Orders = _orderService.SortByName(Orders).ToList();
            return Page();
        }

        /// <summary>
        /// Sorts the orders by name in descending order
        /// </summary>
        /// <returns> Rerenders the page </returns>
        public IActionResult OnGetSortByNameDescending()
        {
            Orders = _orderService.SortByNameDecending(Orders).ToList();
            return Page();
        }

        /// <summary>
        /// Sorts the orders by price
        /// </summary>
        /// <returns> Rerenders the page </returns>
        public IActionResult OnGetSortByPrice()
        {
            Orders = _orderService.SortByPrice(Orders).ToList();
            return Page();
        }

        /// <summary>
        /// Sorts the orders by price in descending order
        /// </summary>
        /// <returns> Rerenders the page </returns>
        public IActionResult OnGetSortByPriceDescending()
        {
            Orders = _orderService.SortByPriceDescending(Orders).ToList();
            return Page();
        }

        /// <summary>
        /// Gets all the orders
        /// </summary>
        public void OnGet()
        {
            Orders = _orderService.GetOrders();
        }
    }
}
