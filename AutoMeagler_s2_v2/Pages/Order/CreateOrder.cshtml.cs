using AutoMeagler_s2_v2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMeagler_s2_v2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace AutoMeagler_s2_v2.Pages.Order
{
    //[Authorize(Roles = "Employee")]
    public class OrderModel : PageModel
    {
        /// <summary>
        /// The service for the orders
        /// </summary>
        private IOrderService _orderService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService"></param>
        public OrderBuyModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// The orders that is to be created
        /// </summary>
        [BindProperty]
        public Models.Order Order { get; set; }

        /// <summary>
        /// The type of order that is to be created
        /// </summary>
        [BindProperty]
        public Models.Order.OrderType SelectedOrderType { get; set; }

        /// <summary>
        /// List of order types for selection in the view
        /// </summary>
        public IEnumerable<SelectListItem> OrderTypes { get; set; }

        /// <summary>
        /// Leasing order Properties
        /// </summary>
        [BindProperty]
        public double? Depositum { get; set; }

        [BindProperty]
        public int StartYear { get; set; }

        [BindProperty]
        public int EndYear { get; set; }

        [BindProperty]
        public int StartMonth { get; set; }

        [BindProperty]
        public int EndMonth { get; set; }

        [BindProperty]
        public int StartDay { get; set; }

        [BindProperty]
        public int EndDay { get; set; }

        [BindProperty]
        public double MonthlyPayment { get; set; }

        /// <summary>
        /// Buy order Properties
        /// </summary>
        [BindProperty]
        public double BuyPrice { get; set; }

        [BindProperty]
        public int BuyYear { get; set; }
        
        [BindProperty]
        public int BuyMonth { get; set; }
        
        [BindProperty]
        public int BuyDay { get; set; }

        /// <summary>
        /// Sale order Properties
        /// </summary>
        [BindProperty]
        public double SalePrice { get; set; }

        [BindProperty]
        public int SaleYear { get; set; }
        
        [BindProperty]
        public int SaleMonth { get; set; }
        
        [BindProperty]
        public int SaleDay { get; set; }

        /// <summary>
        /// Initializes the page with the available order types for selection.
        /// </summary>
        /// <returns> The currect page </returns>
        public IActionResult OnGet()
        {
            OrderTypes = Enum.GetValues(typeof(Models.Order.OrderType))
            .Cast<Models.Order.OrderType>()
            .Select(ot => new SelectListItem
            {
                Value = ot.ToString(),
                Text = ot.ToString()
            });

            return Page();
        }

        /// <summary>
        /// Calls the AddOrder method from the service
        /// </summary>
        /// <returns> To either GetAllOrders page or the same page </returns>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Create the correct order type based on selection
                switch (SelectedOrderType)
                {
                    case Models.Order.OrderType.Leasing:
                        Order = new OrderLeasing
                        {
                            Id = Order.Id,
                            Car = Order.Car,
                            Employee = Order.Employee,
                            Customer = Order.Customer,
                            Type = SelectedOrderType,
                            Depositum = Depositum ?? 0,
                            StartYear = StartYear,
                            EndYear = EndYear,
                            StartMonth = StartMonth,
                            EndMonth = EndMonth,
                            StartDay = StartDay,
                            EndDay = EndDay,
                            MonthlyPayment = MonthlyPayment
                        };
                        break;
                    case Models.Order.OrderType.Buy:
                        Order = new OrderBuy
                        {
                            Id = Order.Id,
                            Car = Order.Car,
                            Employee = Order.Employee,
                            Customer = Order.Customer,
                            Type = SelectedOrderType,
                            BuyPrice = BuyPrice,
                            Year = BuyYear,
                            Month = BuyMonth,
                            Day = BuyDay
                        };
                        break;
                    case Models.Order.OrderType.Sale:
                        Order = new OrderSale
                        {
                            Id = Order.Id,
                            Car = Order.Car,
                            Employee = Order.Employee,
                            Customer = Order.Customer,
                            Type = SelectedOrderType,
                            SalePrice = SalePrice,
                            Year = SaleYear,
                            Month = SaleMonth,
                            Day = SaleDay
                        };
                        break;
                }

                _orderService.AddOrder(Order);
                return RedirectToPage("GetAllOrders");
            }
            // Re-populate OrderTypes for redisplay
            OrderTypes = Enum.GetValues(typeof(Models.Order.OrderType))
                .Cast<Models.Order.OrderType>()
                .Select(ot => new SelectListItem
                {
                    Value = ot.ToString(),
                    Text = ot.ToString()
                });
            return Page();
        }
    }
}
