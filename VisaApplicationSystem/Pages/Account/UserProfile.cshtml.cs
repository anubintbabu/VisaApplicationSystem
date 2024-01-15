using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace VisaApplicationSystem.Pages.Account
{
    public class UserProfileModel : PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Username { get; set; }

        public void OnGet()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            Id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            Name = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            Email = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            PhoneNo = User.Claims.FirstOrDefault(c => c.Type == "PhoneNo").Value;
            Username = User.Claims.FirstOrDefault(c => c.Type == "Username").Value;
        }
    }
}
