using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfoViewModel pagingInfoViewModel,
            Func<int, string> pageUrlBuilder)
        {
            var sb = new StringBuilder();
            for (int i = 1; i < pagingInfoViewModel.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrlBuilder(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfoViewModel.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");
                sb.Append(tag.ToString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}