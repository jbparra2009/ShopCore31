﻿using ShopCore31.Database;
using ShopCore31.Domain.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCore31.Application.Cart
{
    public class RemoveFromCart
    {
        private readonly ISessionManager _sessionManager;
        private readonly IStockManager _stockManager;

        public RemoveFromCart(ISessionManager sessionManager, IStockManager stockManager)
        {
            _sessionManager = sessionManager;
            _stockManager = stockManager;
        }

        public class Request
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        

        public async Task<bool> Do(Request request)
        {
            if (request.Qty <= 0)
            {
                return false;
            }

            await _stockManager.
                RemoveStockFromHold(request.StockId, request.Qty, _sessionManager.GetId());
               
            _sessionManager.RemoveProduct(request.StockId, request.Qty);

            return true;
        }
    }
}