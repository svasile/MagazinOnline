using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MagazinOnline.Domeniu.Entitati
{
    public class Produs
    {
        [HiddenInput(DisplayValue=false)]
        public int ProdusID { get; set; }
        [Required(ErrorMessage = "Vă rog să completaţi denumirea articolului")]
        public string Denumire { get; set; }
        [Required(ErrorMessage = "Vă rog să introduceţi o scurtă descriere a articolului")]
        public string Descriere { get; set; }
        [Required(ErrorMessage = "Trebuie introdus preţul")]
        [Range(0.01,double.MaxValue, ErrorMessage = "Vă rog să introduceţi o valoare pozitivă")]
        public decimal Pret { get; set; }
        [Required(ErrorMessage ="Trebuie menţionată o categorie")]
        public string Categorie { get; set; }
    }
}
