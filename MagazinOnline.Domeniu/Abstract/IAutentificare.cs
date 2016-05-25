namespace MagazinOnline.Domeniu.Abstract
{
    public interface IAutentificare
    {
        bool Autentificare(string utilizator, string parola);
        bool Logout();
    }
}
