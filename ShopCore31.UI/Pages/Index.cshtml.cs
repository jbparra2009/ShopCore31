using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCore31.Application.Products;
using ShopCore31.Database;

namespace ShopCore31.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }
    }
}
