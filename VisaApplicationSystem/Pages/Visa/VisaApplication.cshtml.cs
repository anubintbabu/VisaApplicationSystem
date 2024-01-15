using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VisaApplicationSystem.Pages.Visa
{
    public class VisaApplicationModel : PageModel
    {
        public int Id { get; set; }

        public void OnGet()
        {
            //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            //Id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
        }
    }
}
