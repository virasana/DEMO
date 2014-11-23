using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvitesWebApp.Models
{
    public class InvitationsCalculator
    {
        public decimal GetTotalInvitations(IEnumerable<GuestResponse> guestResponses)
        {
            return guestResponses.Sum(p => p.NumberOfFriends);
        }
    }
}