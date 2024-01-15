using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisaApplicationSystem.Models
{
    public class VisaApplications
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("FK_VisaApplications_VisaType")]
        [Required]
        public int VisaType { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string SpouseName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string BirthCity { get; set; }
        //[ForeignKey("FK_VisaApplication_Countries1")]
        [Required]
        public int BirthCountry { get; set; }
        //[ForeignKey("FK_VisaApplication_Countries3")]
        [Required]
        public int Nationality { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string PassportNo { get; set; }
        [Required]
        public DateOnly IssueDate { get; set; }
        [Required]
        public DateOnly ExpiryDate { get; set; }
        //[ForeignKey("FK_VisaApplication_Countries")]
        [Required]
        public int IssuingCountry { get; set; }
       
        public string SponsorName { get; set; }
        
        public string Relationship { get; set; }
        //[ForeignKey("FK_VisaApplication_Countries2")]
        public int SponsorNationality { get; set; }

        public string BusinessAddress { get; set; }

        public string TelNo { get; set; }

        public string SponsorMobile { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Passport { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateOnly CreatedDate { get; set; }
        [Required]
        public int CreatedBy { get; set; }
    }
    public class TableJoinResult
    {
        public VisaApplications Table1 { get; set; }
        public VisaTypes Table2 { get; set; }
    }
}
