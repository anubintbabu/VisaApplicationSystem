namespace VisaApplicationSystem.Models
{
    public class Countries
    {

        public int Id { get; set; }

        public string Country { get; set; } = null!;

        public string CountryCode { get; set; } = null!;

        public string? Nationality { get; set; }

        //public virtual ICollection<VisaApplications> FK_VisaApplication_Countries1 { get; set; }

        //public virtual ICollection<VisaApplications> FK_VisaApplication_Countries { get; set; }

        //public virtual ICollection<VisaApplications> FK_VisaApplication_Countries3 { get; set; }

        //public virtual ICollection<VisaApplications> FK_VisaApplication_Countries2 { get; set; }
    }
}
