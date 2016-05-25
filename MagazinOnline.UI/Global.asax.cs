using MagazinOnline.Domeniu.Entitati;
using MagazinOnline.UI.Legaturi;
using System.Web.Mvc;
using System.Web.Routing;
using MySql.Data.Entity;
using System.Data.Entity;

namespace MagazinOnline.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Cos), new CosLegatura());

            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }
    }
}
