using Microsoft.EntityFrameworkCore;
using ShopCore31.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopCore31.Application.Products
{
    public class GetProducts
    {
        private readonly ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _ctx.Products
                .Include(x => x.Stock).AsEnumerable()
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = $"${x.Value.ToString("N2")}", // 1100.50 => 1,100.50 => $ 1,100.50

                    StockCount = x.Stock.Sum(y => y.Qty)
                })
                .ToList();


        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public int StockCount { get; set; }
        }
    }
}
