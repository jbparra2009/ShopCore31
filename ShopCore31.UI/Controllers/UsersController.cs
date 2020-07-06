using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopCore31.UI.ViewModels.Admin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopCore31.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateUSer(
            [FromBody] CreateUserViewModel vm)
        {
            var managerUser = new IdentityUser()
            {
                UserName = vm.Username
            };

            await _userManager.CreateAsync(managerUser, "password");

            var managerClaim = new Claim("Role", "Manager");

            await _userManager.AddClaimAsync(managerUser, managerClaim);

            return Ok();
        }
    }
}
