using MagazinOnline.Domeniu.Abstract;
using MagazinOnline.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace MagazinOnline.UI.Controllers
{
    public class ProdusController : Controller
    {
        private readonly IDepozitProduse depozit;
        public int DimensiunePagina = 3;
        public ProdusController(IDepozitProduse deprod)
        {
            depozit = deprod;
        }

        public ViewResult List(string categoria,int pagina = 1)
        {
            ListaProduse model = new ListaProduse
            {
                Produse = depozit.Produse
                .Where(p=>categoria==null||p.Categorie==categoria)
                .OrderBy(p => p.ProdusID)
                .Skip((pagina-1) * DimensiunePagina)
                .Take(DimensiunePagina),
                InfoPaginare = new InfoPaginare
                {
                    PaginaCurenta = pagina,
                    ArticolePePagina = DimensiunePagina,
                    TotalArticole = categoria==null?
                                    depozit.Produse.Count():
                                    depozit.Produse.Where(p=>p.Categorie==categoria).Count()
                },
                CategoriaCurenta=categoria
            };
            return View(model);
        }
    }
}