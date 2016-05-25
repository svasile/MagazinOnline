using MagazinOnline.Domeniu.Abstract;
using MagazinOnline.Domeniu.Entitati;
using System.Linq;
using System.Web.Mvc;

namespace MagazinOnline.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IDepozitProduse depozit;

        public AdminController(IDepozitProduse deprod)
        {
            depozit = deprod;
        }

        public ActionResult Index()
        {
            return View(depozit.Produse);
        }

        public ViewResult Adauga()
        {
            return View(new Produs());
        }

        [HttpPost]
        public ActionResult Adauga(Produs produs)
        {
            if (ModelState.IsValid)
            {
                depozit.SalveazaProdus(produs);
                TempData["mesaj"] = string.Format("{0} a fost adăugat", produs.Denumire);
                return RedirectToAction("Index");
            }
            else
            {
                return View(produs);
            }
        }

        public ViewResult Modifica(int produsId)
        {
            Produs produs = depozit.Produse.FirstOrDefault(p => p.ProdusID == produsId);

            return View(produs);
        }

        [HttpPost]
        public ActionResult Modifica(Produs produs)
        {
            if(ModelState.IsValid)
            {
                depozit.SalveazaProdus(produs);
                TempData["mesaj"] = string.Format("{0} a fost modificat", produs.Denumire);
                return RedirectToAction("Index");
            }
            else
            {
                return View(produs);
            }
        }

        [HttpPost]
        public ActionResult Sterge(int produsId)
        {
            Produs stergeProdus = depozit.StergeProdus(produsId);
            if (stergeProdus!=null)
            {
                TempData["mesaj"] = string.Format("{0} a fost şters", stergeProdus.Denumire);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}