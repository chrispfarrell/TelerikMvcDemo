using System.Web.Mvc;

namespace TelerikMvc.Web.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static string GetCurrentTheme(this HtmlHelper html)
        {
            return html.ViewContext.HttpContext.Request.QueryString["theme"] ?? "vista";
        }
    }
}