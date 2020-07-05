using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCore31.Application.UsersAdmin;
using ShopCore31.Database;
using System.Threading.Tasks;

namespace ShopCore31.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private CreateUser _createUSer;

        public UsersController(CreateUser createUser)
        {
            _createUSer = createUser;
        }

        public async Task<IActionResult> CreateUSer([FromBody] CreateUser.Request request)
        {
            await _createUSer.Do(request);

            return Ok();
        }

        
    }
}
