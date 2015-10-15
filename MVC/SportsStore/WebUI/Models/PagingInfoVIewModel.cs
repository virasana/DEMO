using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PagingInfoViewModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                var result= (int)Math.Ceiling((decimal) TotalItems/ItemsPerPage);
                return result;
            }
        }

        public string Category { get; set; }
    }
}