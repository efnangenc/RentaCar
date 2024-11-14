using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using RentAndSell.Car.API.Data.Entities.Concrete;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RentAndSell.Car.API.Services
{
    public class YetkiKontrolYakalayicisi : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly UserManager<Kullanici> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Kullanici> _signInManager;
        public YetkiKontrolYakalayicisi(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, UserManager<Kullanici> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Kullanici> signInManager) : base(options, logger, encoder)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        //Api da login etme authentication ekleme.
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {


            if (Request.Headers.ContainsKey("Authorication"))
            {
                string authorication = Request.Headers["Authorication"];
                string base64Encode = authorication.Split("Basic ")[1];
                string authDecode = Encoding.UTF8.GetString(Convert.FromBase64String(base64Encode));
                string[] credentials = authDecode.Split(":");
                string userName = credentials[0];
                string password = credentials[1];


                Kullanici? kullanici = _userManager.FindByNameAsync(userName).Result;

                if (kullanici is null)
                {

                    return AuthenticateResult.Fail("kullanıcı adı veya şifre yanlış");
                }

                bool passwordChecked = _userManager.CheckPasswordAsync(kullanici, password).Result;

                if (!passwordChecked)
                {
                    return AuthenticateResult.Fail("kullanıcı adı veya şifre yanlış");

                }

                _signInManager.AuthenticationScheme = Scheme.Name;

                SignInResult signInResult = _signInManager.CheckPasswordSignInAsync(kullanici, password, false).Result;


                if (signInResult.IsLockedOut)
                {
                    return AuthenticateResult.Fail("Hesabınız kilitlenmiştir. Lütfen yetkili birim ile görüşün");
                }

                if (signInResult.IsNotAllowed)
                {
                    return AuthenticateResult.Fail("Hesabınız henüz doğrulanmamıştır.Lütfen mail adresine gelen linke tıklayınız");
                }

                if (signInResult.RequiresTwoFactor)
                {
                    return AuthenticateResult.Fail("İkili doğrulama işlemi gerçekleştirnemiz gerekiyor.");
                }


                if (signInResult.Succeeded)
                {
                    List<Claim> claims = _userManager.GetClaimsAsync(kullanici).Result.ToList();

                    //List<Claim> claims = new List<Claim>()
                    //    {
                    //new Claim(ClaimTypes.NameIdentifier, kullanici.Id),
                    //new Claim(ClaimTypes.Name, kullanici.UserName,
                    //new Claim(ClaimTypes.Email, kullanici.Email)
                    //    };

                    ClaimsIdentity clasimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(clasimsIdentity);

                    AuthenticationTicket gecisBileti = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                    return AuthenticateResult.Success(gecisBileti);
                }
                return AuthenticateResult.Fail("Yetkisiz giriş denemesi.");
            }
            return AuthenticateResult.Fail("Yetkisiz giriş denemesi.");
        }
    }
}