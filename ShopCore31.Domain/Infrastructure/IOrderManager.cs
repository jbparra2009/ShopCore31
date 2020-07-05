using ShopCore31.Domain.Models;
using System.Threading.Tasks;

namespace ShopCore31.Domain.Infrastructure
{
    public interface IOrderManager
    {
        Task CreateOreder(Order order);
    }
}
