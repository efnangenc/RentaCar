using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RentAndSell.Car.API.Data.Entities.Concrete;
using RentAndSell.Car.API.Models;
using RentAndSell.Car.API.Services;
using System.Security.Cryptography;
using System.Text;

namespace RentAndSell.Car.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        public AuthController(SignInManager<Kullanici> signInManager, UserManager<Kullanici> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginViewModel model)
        {
            LoginResultViewModel loginResult = new LoginResultViewModel();
            Kullanici? kullanici = _userManager.FindByNameAsync(model.UserName).Result;
            if (kullanici == null)
            {
                loginResult.IsLogin = false;
                loginResult.ErrorMessage = "kullanıcı adı veya şifre yanlış";
                return Unauthorized(loginResult);
            }

            bool passwordChecked = _userManager.CheckPasswordAsync(kullanici, model.Password).Result;

            if (!passwordChecked)
            {
                loginResult.IsLogin = false;
                loginResult.ErrorMessage = "kullanıcı adı veya şifre yanlış";
                return Unauthorized(loginResult);
            }

            #region BasicAuth kodları
            //var usernamePAssword = $"{model.UserName}:{model.Password}";
            //var base64EncodeUserNamePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernamePAssword));
            //var basicAuth = $"Basic {base64EncodeUserNamePassword}";

            //loginResult.IsLogin = true;
            //loginResult.BasicAuth = basicAuth; 
            #endregion

            #region Custom Auth Token Kodalrı

            var base64EncodeUserNameWithToken = CustomToken.GenerateToken(model.UserName);
            var basicAuth = $"CustomToken {base64EncodeUserNameWithToken}";

            loginResult.IsLogin = true;
            loginResult.BasicAuth = basicAuth;
            #endregion

            return Ok(loginResult);
        }
    }
}
