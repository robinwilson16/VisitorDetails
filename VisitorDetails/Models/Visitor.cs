using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace VisitorDetails.Models
{
    [Table("VIS_Visitor")]
    public class Visitor
    {
        public int VisitorID { get; set; }

        [StringLength(20)]

        [Display(Name = "Site*", Prompt = "Site you are visiting?")]
        [Required(ErrorMessage = "Please confirm which college site you are visiting")]
        public string SiteCode { get; set; }

        [Display(Name = "Surname*", Prompt = "Your Surname?")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Surname must be at least 3 characters")]
        [Required(ErrorMessage = "Please provide your last name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only please")]
        public string Surname { get; set; }

        [Display(Name = "Forename*", Prompt = "Your Forename?")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Forename must be at least 2 characters")]
        [Required(ErrorMessage = "Please provide your first name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only please")]
        public string Forename { get; set; }

        [Display(Name = "Mobile*", Prompt = "Your Mobile Number?")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Phone number is too short")]
        [RegularExpression(@"^[0-9]+[ 09]*$", ErrorMessage = "Mobile number is not valid")]
        [RequiredIf("MobileOptOut == false", ErrorMessage = "Please provide your mobile number or tick to opt out")]
        public string MobileTel { get; set; }

        [Display(Name = "Opt out of providing mobile", Prompt = "Prefer to opt out")]
        public bool MobileOptOut { get; set; }

        [Display(Name = "Number of Guests with You*", Prompt = "Number of Guests With You?")]
        [Required(ErrorMessage = "Please confirm how many guests you have with you")]
        public int? NumberOfGuests { get; set; }

        [Display(Name = "Purpose for Your Visit*", Prompt = "Purpose for Your Visit?")]
        [Required(ErrorMessage = "Please confirm the purpose for your visit to WLC")]
        public int PurposeOfVisitID { get; set; }

        [Display(Name = "Date / Time Entered")]
        [Required(ErrorMessage = "Please confirm the current date/time")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Date / Time Left")]
        public DateTime? LeaveDate { get; set; }

        [Display(Name = "IP Address")]
        [StringLength(45)]
        public string IPAddress { get; set; }

        [Display(Name = "Browser Info")]
        public string UserAgent { get; set; }

        public Site Site { get; set; }
        public PurposeOfVisit PurposeOfVisit { get; set; }

    }
}
