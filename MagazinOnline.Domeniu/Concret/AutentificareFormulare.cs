using MagazinOnline.Domeniu.Abstract;
using System.Linq;

namespace MagazinOnline.Domeniu.Concret
{
    public class AutentificareFormulare : IAutentificare
    {
        private readonly EFDbContext context = new EFDbContext();

        public bool Autentificare(string utilizator, string parola)
        {
            var rezultat=context.Utilizatori.FirstOrDefault(u=>u.UtilizatorID==utilizator && u.Parola==parola);
            if(rezultat==null)
                return false;    
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
