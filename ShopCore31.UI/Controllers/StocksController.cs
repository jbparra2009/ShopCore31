﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCore31.Application.StockAdmin;
using ShopCore31.Database;
using System.Threading.Tasks;

namespace ShopCore31.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class StocksController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public StocksController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        // Methods for Stocks

        [HttpGet("")]
        public IActionResult GetStock() => Ok(new GetStock(_ctx).Do());

        [HttpPost("")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request request) => Ok(await new CreateStock(_ctx).Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id) => Ok((await new DeleteStock(_ctx).Do(id)));

        [HttpPut("")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request) => Ok((await new UpdateStock(_ctx).Do(request)));

    }
}
