using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvitesWebApp.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must indicate whether you are attending or not.")]
        public bool? WillAttend { get; set; }

        [Required(ErrorMessage = "You must indicate the number of friends who will be joining you.")]
        public int NumberOfFriends { get; set; }
    }
}