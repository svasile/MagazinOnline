using MagazinOnline.Domeniu.Abstract;
using MagazinOnline.Domeniu.Entitati;
using MagazinOnline.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace MagazinOnline.UI.Controllers
{
    public class CosController : Controller
    {
        private IDepozitProduse depozit;
        private IProcesareComanda procesarecomanda;

        public CosController(IDepozitProduse deprod, IProcesareComanda procom)
        {
            depozit = deprod;
            procesarecomanda = procom;
        }

        public ViewResult Index(Cos cos, string returnUrl)
        {
            return View(new CosIndex { Cos = cos, ReturnUrl = returnUrl });
        }

        public PartialViewResult Cuprins(Cos cos)
        {
            return PartialView(cos);
        }

        public ViewResult Verifica()
        {
            return View(new DetaliiCumparaturi());
        }

        [HttpPost]
        public ViewResult Verifica(Cos cos, DetaliiCumparaturi detaliiCumparaturi)
        {
            if(cos.rand.Count()==0)
            {
                ModelState.AddModelError("", "Ne pare rău, coşul tău este gol!");
            }
            if(ModelState.IsValid)
            {
                procesarecomanda.ProcesareComanda(cos, detaliiCumparaturi);
                cos.Golire();
                return View("Finalizat");
            }
            else
            {
                return View(detaliiCumparaturi);
            }
        }

        public RedirectToRouteResult PuneInCos(Cos cos, int produsid, string returnUrl)
        {
            Produs produs = depozit.Produse.FirstOrDefault(p => p.ProdusID == produsid);
            if(produs!=null)
            {
                cos.AddItem(produs, 1);
            }
            return RedirectToAction("Index", new { returnUrl});
        }

        public RedirectToRouteResult StergeDinCos(Cos cos, int produsid,string returnUrl)
        {
            Produs produs = depozit.Produse.FirstOrDefault(p=>p.ProdusID==produsid);
            if(produs!=null)
            {
                cos.StergeCoada(produs);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}