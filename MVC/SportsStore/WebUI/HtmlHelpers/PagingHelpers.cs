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
        public delegate string PageBuilderDelegate(int page, string category);

        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfoViewModel pagingInfoViewModel,
            PageBuilderDelegate pageUrlBuilder)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= pagingInfoViewModel.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrlBuilder(i, pagingInfoViewModel.Category));
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