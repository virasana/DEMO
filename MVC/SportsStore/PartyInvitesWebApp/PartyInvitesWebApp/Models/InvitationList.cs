using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvitesWebApp.Models
{
    public class InvitationList
    {
        private InvitationsCalculator _calc;
        public InvitationList(InvitationsCalculator calc)
        {
            _calc = calc;
        }

        public decimal GetNumberOfGuests()
        {
            return _calc.GetTotalInvitations(this.GuestResponses);
        }

        public IEnumerable<GuestResponse> GuestResponses { get; set; }
    }
}