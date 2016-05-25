using System.ComponentModel.DataAnnotations;

namespace MagazinOnline.Domeniu.Entitati
{
    public class DetaliiCumparaturi
    {
        [Required(ErrorMessage ="Trebuie să vă scrieţi numele")]
        public string Numele { get; set; }
        [Required(ErrorMessage = "Trebuie să vă scrieţi adresa")]
        public string Adresa1 { get; set; }
        public string Adresa2 { get; set; }
        public string Adresa3 { get; set; }
        [Required(ErrorMessage = "Trebuie să scrieţi oraşul")]
        public string Orasul { get; set; }
        [Required(ErrorMessage = "Trebuie să scrieţi judeţul")]
        public string Judetul { get; set; }
        [Required(ErrorMessage = "Trebuie să scrieţi ţara")]
        public string Tara{ get; set; }
        public bool Cadou { get; set; }
    }
}
