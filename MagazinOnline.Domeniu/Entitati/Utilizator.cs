using System.ComponentModel.DataAnnotations;

namespace MagazinOnline.Domeniu.Entitati
{
    public class Utilizator
    {
        [Key]
        public string UtilizatorID { get; set; }
        public string Parola {get;set;}
    }
}
