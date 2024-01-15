using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace VisaApplicationSystem.Pages.Account
{
    public class DashboardModel : PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void OnGet()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            if (currentUser.Identity.IsAuthenticated == true)
            {
                Id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
                Name = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            }

        }
    }
}
