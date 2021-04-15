using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.ApiPlusAngular.Helper;
using Auth.DataAccess;
using Auth.DataAccess.Entity;
using Auth.Domain.Interfaces;
using Auth.DTO;
using Auth.DTO.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth.ApiPlusAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _IJWTTokenService;

        public AccountController(
            EFContext context,
            IJWTTokenService IJWTTokenService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _IJWTTokenService = IJWTTokenService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ResultDTO> Register([FromBody] UserRegisterDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Code = 405,
                        Message = "ERROR!",
                        Errors = new List<string>()
                        {
                            "Enter all fields!"
                        }
                    };
                }
                else
                {
                    var user = new User
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.Phone,
                        Address = model.Address,
                        Age = model.Age,
                        FullName = model.FullName
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(user, "User").Result;
                        _context.SaveChanges();

                        return new ResultDTO
                        {
                            Code = 200,
                            Message = "OK!"
                        };
                    }
                    else
                    {
                        return new ResultErrorDTO
                        {
                            Code = 405,
                            Message = "ERROR!",
                            Errors = CustomValidator.getErrorsByIdentityResult(result)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "ERROR!",
                    Errors = new List<string>
                    {
                        e.Message
                    }
                };
            }
        }

        [HttpPost("login")]
        public async Task<ResultDTO> Login([FromBody] UserLoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Code = 405,
                        Message = "ERROR!",
                        Errors = CustomValidator.getErrorsByModelState(ModelState)
                    };
                }
                else
                {
                    var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false).Result;

                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        await _signInManager.SignInAsync(user, false);

                        return new ResultLoginDTO
                        {
                            Code = 200,
                            Message = "OK!",
                            Token = _IJWTTokenService.CreateToken(user)
                        };
                    }
                    else
                    {
                        return new ResultErrorDTO
                        {
                            Code = 405,
                            Message = "ERROR!",
                            Errors = new List<string>()
                            {
                                "Incorrect email or password!"
                            }
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "ERROR!",
                    Errors = new List<string>
                    {
                        e.Message
                    }
                };
            }
        }

    }
}
