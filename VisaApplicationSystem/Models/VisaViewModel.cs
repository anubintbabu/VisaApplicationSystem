using System.ComponentModel.DataAnnotations;

namespace VisaApplicationSystem.Models
{
    public class VisaViewModel
    {
       
        public string VisaType { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }
        public DateOnly CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Photo { get; set; }
    }
}
