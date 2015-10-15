using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvitesWebApp.Models;

namespace PartyInvitesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuestResponse[] _guestResponses =
        {
            new RandomGuest(),
            new RandomGuest(),
            new RandomGuest()
        };

        // GET: Home
        public ViewResult Index()
        {
            ViewBag.Greeting = (DateTime.Now.Hour < 12) ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult InvitationList()
        {
            var invitationList = new InvitationList(new InvitationsCalculator()) {GuestResponses = _guestResponses};
            return View("InvitationList", invitationList);
        }
    }
}