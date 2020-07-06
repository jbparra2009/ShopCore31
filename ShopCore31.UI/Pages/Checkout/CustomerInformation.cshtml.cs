using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using ShopCore31.Application.Cart;

namespace ShopCore31.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        //private readonly IHostingEnvironment _env;

        public CustomerInformationModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }

        public IActionResult OnGet(
            [FromServices] GetCustomerInformation getCustomerInformation)
        {
            // Get Cart
            var information = getCustomerInformation.Do();

            // If Cart exist go to payment
            if (information == null)
            {
                if (_env.IsDevelopment())
                {
                    CustomerInformation = new AddCustomerInformation.Request
                    {
                        FirstName = "Jaime",
                        LastName = "Barras",
                        Email = "jabarras@hotmail.com",
                        PhoneNumber = "(866) 555-1234",
                        Address1 = "Home Address",
                        Address2 = "Office Address",
                        City = "New York",
                        ZipCode = "25078",
                    };
                }

                return Page();
            }
            else
            {
                return RedirectToPage("/Checkout/Payment");
            }

        }

        public IActionResult OnPost([FromServices] AddCustomerInformation addCustomerInformation)
        {
            // Post Cart
            if (!ModelState.IsValid)
            {
                return Page();
            }

            addCustomerInformation.Do(CustomerInformation);

            return RedirectToPage("/Checkout/Payment");
        }
    }
}
