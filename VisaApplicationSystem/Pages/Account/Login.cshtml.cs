using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data;
using VisaApplicationSystem.Models;
using Microsoft.EntityFrameworkCore;
using VisaApplicationSystem.Data;

namespace VisaApplicationSystem.Pages.Account
{
    public class LoginModel : PageModel
    {
        [Required]
        [Display(Name = "User name")]
        [BindProperty]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [BindProperty]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        [BindProperty]
        public bool RememberMe { get; set; }
        private readonly ApplicationDbContext dbContext;

        public LoginModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var hashpassword = GetHashPassword(Password.Trim());
            var user = dbContext.UserProfiles.FirstOrDefault(u => u.Username == Username && u.Password == hashpassword);
          
            if (user == null)
            {
                TempData["ErrorMessage"] = "Username or Password Invalid!!";
                return Page();
            }
            

            //string[] roles = (await _userRepository.GetUserRoles(user.UserId)).ToArray();

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim("UserID", user.UserId.ToString()));
            identity.AddClaim(new Claim("Name", user.Name));
            identity.AddClaim(new Claim("Email", user.Email));
            identity.AddClaim(new Claim("PhoneNo", user.PhoneNo));
            identity.AddClaim(new Claim("Username", user.Username));

            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties
            {
                IsPersistent = RememberMe
            };

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();


            return Redirect("/dashboard");
        }

        public string GetHashPassword(string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.ASCII.GetBytes("visa"),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
       
    }
}
