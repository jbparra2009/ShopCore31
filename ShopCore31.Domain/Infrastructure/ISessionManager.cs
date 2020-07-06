using ShopCore31.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShopCore31.Domain.Infrastructure
{
    public interface ISessionManager
    {
        string GetId();
        void AddProduct(CartProduct cartProduct);
        void RemoveProduct(int stockId, int qty);
        IEnumerable<TResult> GetCart<TResult>(Func<CartProduct, TResult> selector);
        void ClearCart();

        void AddCustomerInformation(CustomerInformation customer);
        CustomerInformation GetCustomerInformation();
    }
}
