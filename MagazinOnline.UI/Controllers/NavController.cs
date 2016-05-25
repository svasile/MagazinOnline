using MagazinOnline.Domeniu.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MagazinOnline.UI.Controllers
{
    public class NavController : Controller
    {
        private IDepozitProduse depozit;

        public NavController(IDepozitProduse deprod)
        {
            depozit = deprod;
        }

        public PartialViewResult Meniu(string categoria=null)
        {
            ViewBag.CategoriaSelectata = categoria;

            IEnumerable<string> categorii = depozit.Produse
                .Select(x => x.Categorie)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categorii);
        }
    }
}