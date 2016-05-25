using MagazinOnline.UI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace MagazinOnline.UI.HtmlAjutoare
{
    public static class AjutorPaginare
    {
        public static MvcHtmlString LinkPagina (this HtmlHelper html, 
                    InfoPaginare infoPaginare, Func<int,string>UrlPagina)
        {
            StringBuilder rezultat = new StringBuilder();
            for(int i=1; i<=infoPaginare.TotalPagini;i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", UrlPagina(i));
                tag.InnerHtml = i.ToString();
                if(i==infoPaginare.PaginaCurenta)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                rezultat.Append(tag.ToString());
            }
            return MvcHtmlString.Create(rezultat.ToString());
        }
    }
}
