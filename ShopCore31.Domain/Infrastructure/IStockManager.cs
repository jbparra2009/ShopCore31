using ShopCore31.Domain.Models;
using System.Threading.Tasks;

namespace ShopCore31.Domain.Infrastructure
{
        // Episode 38 - Refactoring Cart and Database
        public interface IStockManager
        {
            Stock GetStockWithProduct(int stockId);
            bool EnoughStock(int stockId, int qty);
            Task PutStockOnHold(int stockId, int qty, string sessionId);
            Task RemoveStockFromHold(int stockId, int qty, string sessionId);
        }

}
