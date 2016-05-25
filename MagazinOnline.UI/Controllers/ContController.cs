using MagazinOnline.Domeniu.Abstract;
using MagazinOnline.UI.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MagazinOnline.UI.Controllers
{
    [Authorize]
    public class ContController : Controller
    {
        IAutentificare autentificare;
        public ContController(IAutentificare autentificare)
        {
            this.autentificare = autentificare;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogareModel logare, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(autentificare.Autentificare(logare.Utilizator,logare.Parola))
                {
                    FormsAuthentication.SetAuthCookie(logare.Utilizator, false);
                    return Redirect(returnUrl ?? Url.Action("Index","Admin"));
                }
                else
                {
                    ModelState.AddModelError("","Parola şi/sau utilizatorul incorectă(e)!");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }
        //Schimba parola
        //Uitata parola
    }
}