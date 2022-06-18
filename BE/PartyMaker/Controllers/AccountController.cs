using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyMaker.Application.Interfaces;
using System.Threading.Tasks;

namespace PartyMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        //[HttpGet("login")]
        //public async Task<IActionResult> Login([FromQuery] )
        //{
        //}
    }
}
