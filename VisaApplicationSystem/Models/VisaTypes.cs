using System.ComponentModel.DataAnnotations;

namespace VisaApplicationSystem.Models
{
    public class VisaTypes
    {
        [Key]
        public int Id { get; set; }

        public string VisaType { get; set; } = null!;

        public int NoOfDays { get; set; }

        //public ICollection<VisaApplications> FK_VisaApplications_VisaType { get; set; }
    }
}
