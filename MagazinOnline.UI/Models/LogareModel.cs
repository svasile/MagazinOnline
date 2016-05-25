using System.ComponentModel.DataAnnotations;

namespace MagazinOnline.UI.Models
{
    public class LogareModel
    {
        [Required (ErrorMessage ="Trebuie completat utilizatorul")]
        public string Utilizator { get; set; }
        [Required(ErrorMessage = "Trebuie introdusă parola")]
        [StringLength(50, MinimumLength =6)]
        public string Parola{ get; set; }
    }
}
