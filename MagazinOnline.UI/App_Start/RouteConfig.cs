using System.Web.Mvc;
using System.Web.Routing;

namespace MagazinOnline.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    Controller = "Produs",
                    Action="List",
                    categoria=(string)null,
                    pagina=1
                });

            routes.MapRoute(null, "Pagina{pagina}",
                new
                {
                    Controller = "Produs",
                    Action = "List",
                    categoria = (string)null
                },
                new { pagina = @"\d+" });

            routes.MapRoute(null, "{categoria}",
                new
                {
                    Controller = "Produs",
                    Action = "List",
                    pagina = 1
                });

            routes.MapRoute(null, "{categoria}/Pagina{pagina}",
                new
                {
                    Controller = "Produs",
                    Action = "List"
                },
                new { pagina = @"\d+" });

            routes.MapRoute(null, "{Controller}/{Action}");
        }
    }
}
