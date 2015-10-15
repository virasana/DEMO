using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvitesWebApp.Models
{
    public class RandomGuest : GuestResponse
    {
        public RandomGuest()
        {
            Initialise();
        }

        private void Initialise()
        {
            var random = new Random();
            this.Email = new string('$', random.Next(1, 10));
            this.Phone = new string(Convert.ToChar(random.Next(1, 10)), random.Next(1, 10));
            this.Name = new string('£', random.Next(1, 10));
            this.NumberOfFriends = random.Next(1, 10);
            this.WillAttend = random.Next(1, 10) % 2 == 0;
        }
    }
}