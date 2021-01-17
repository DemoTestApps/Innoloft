using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Innoloft.Demo.Api.Models;
using Innoloft.Demo.Api.Models.User;
using Innoloft.Demo.Core.Entity.Identity;
using Innoloft.Demo.Service.Authentication;
using Innoloft.Demo.Service.Users;

namespace Innoloft.Demo.Api.Controllers
{    
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IAuthenticationService _authenticationService;
        public UserController(UserManager<User> userManager)
        {
            _userRegistrationService = new UserRegistrationService(userManager);
            _authenticationService = new AuthenticationService(userManager);
        }

        [HttpPost]
        [Route("account/register")]
        public async Task<IActionResult> PostRegister(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserRegistrationRequest request = new UserRegistrationRequest(model.FirstName, model.LastName, model.PhoneNumber,
                      model.Email, model.BirthDate, model.Password, "InnoloftUser");

                var response = await _userRegistrationService.RegisterUser(request);

                if (response.Success)
                {
                    return Ok(response);
                }
                foreach (var e in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, e);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> PostLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserLoginResult loginResult = await _userRegistrationService.ValidateUser(model.UserName, model.Password);
                switch (loginResult)
                {
                    case UserLoginResult.Successful:
                        User user = await _userRegistrationService.GetUserByUserName(model.UserName);
                        AuthenticationResult result = await _authenticationService.AuthenticateUser(user);
                        if (result.Success)
                        {
                            return Ok(model.PrepareLoginSuccessModel(result));
                        }
                        ModelState.AddModelError(string.Empty, "Login Failed");
                        break;
                    case UserLoginResult.UserNotExist:
                        ModelState.AddModelError(string.Empty, "User not exist");
                        break;
                    case UserLoginResult.WrongPassword:
                        ModelState.AddModelError(string.Empty, "Wrong Credential");
                        break;
                    case UserLoginResult.NotActive:
                        ModelState.AddModelError(string.Empty, "User Inactive");
                        break;
                    case UserLoginResult.LockedOut:
                        ModelState.AddModelError(string.Empty, "Profile Locked");
                        break;
                }
            }
            return BadRequest(ModelState.Select(x=>x.Value.Errors.First().ErrorMessage));
        }
    }
}
