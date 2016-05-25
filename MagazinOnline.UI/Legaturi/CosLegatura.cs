using MagazinOnline.Domeniu.Entitati;
using System.Web.Mvc;

namespace MagazinOnline.UI.Legaturi
{
    public class CosLegatura : IModelBinder
    {
        private const string sessionKey = "Cos";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cos cos = null;
            if(controllerContext.HttpContext.Session !=null)
            {
                cos = (Cos)controllerContext.HttpContext.Session[sessionKey];
            }
            if(cos==null)
            {
                cos = new Cos();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey]=cos;
                }
            }
            return cos;
        }
    }
}
