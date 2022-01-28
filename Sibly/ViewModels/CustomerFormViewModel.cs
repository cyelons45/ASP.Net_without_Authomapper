using Sibly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibly.ViewModels
{
    public class CustomerFormViewModel
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
        public DateTime? Birthdate { get; set; }


        public string Title { get 
        {
            return CustomerId == 0 ? "New Customer" : "Edit Customer";
        }
        }


        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public CustomerFormViewModel()
        {
            CustomerId = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            CustomerId = customer.CustomerId;
            Name = customer.Name;
            isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
            Birthdate = customer.Birthdate;
            MembershipTypeId = customer.MembershipTypeId;
            MembershipType = customer.MembershipType;
       
        }
    }
}