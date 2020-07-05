﻿using ShopCore31.Database;
using ShopCore31.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ShopCore31.Application.OrdersAdmin
{
    public class GetOrders
    {
        private readonly ApplicationDbContext _ctx;

        public GetOrders(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }
            public string Email { get; set; }
        }

        public IEnumerable<Response> Do(int status) =>
            _ctx.Orders
                .Where(x => x.Status == (OrderStatus)status)
                .Select(x => new Response
                {
                    Id = x.Id,
                    OrderRef = x.OrderRef,
                    Email = x.Email
                })
                .ToList();
    }
}
