using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class MenuViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
    }
}