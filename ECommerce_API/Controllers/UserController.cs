using ECommerce_API.Models;
using ECommerce_API.Parent;
using ECommerce_API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using ViewModel;

namespace ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<VMMUser, IUserRepository, int>
    {
        public UserController(IUserRepository repository) : base(repository)
        {
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(VMLogin login)
        {
            try
            {
                VMResponse<VMMBiodata>? response = await Task.Run(() => _repository.LoginAsync(login));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to retrieve data : " + e.Message);
                return BadRequest("An error occurred while trying to retrieve data : " + e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(VMRegister register)
        {
            try
            {
                VMResponse<VMMUser>? response = await Task.Run(() => _repository.RegisterAsync(register));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to retrieve data : " + e.Message);
                return BadRequest("An error occurred while trying to retrieve data : " + e.Message);
            }
        }
    }
}
