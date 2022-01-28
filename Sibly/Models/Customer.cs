using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Sibly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        [Required]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Date of Birth  (MM/DD/YYYY)")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

  
    }
}