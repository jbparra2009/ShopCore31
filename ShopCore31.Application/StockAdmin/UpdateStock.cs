using ShopCore31.Domain.Infrastructure;
using ShopCore31.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopCore31.Application.StockAdmin
{
    [Service]
    public class UpdateStock
    {
        private readonly IStockManager _stockManager;

        public UpdateStock(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public async Task<Response> Do(Request request)
        {
            var stockList = new List<Stock>();

            foreach (var stock in request.Stock)
            {
                stockList.Add(new Stock
                {
                    Id = stock.Id,
                    Description = stock.Description,
                    Qty = stock.Qty,
                    ProductId = stock.ProductId
                });
            }

            await _stockManager.UpdateStockRange(stockList);

            return new Response
            {
                Stock = request.Stock
            };
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }

        public class Request
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class Response
        {
            public IEnumerable<StockViewModel> Stock { get; set; }

        }
    }
}
