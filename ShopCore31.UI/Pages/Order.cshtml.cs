using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCore31.Application.Orders;

namespace ShopCore31.UI.Pages
{
    public class OrderModel : PageModel
    {
        public GetOrder.Response Order { get; set; }

        public void OnGet(
            string reference,
            [FromServices] GetOrder getOrder)
        {
            Order = getOrder.Do(reference);
        }
    }
}
