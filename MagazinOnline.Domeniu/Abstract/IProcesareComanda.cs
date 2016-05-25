using MagazinOnline.Domeniu.Entitati;

namespace MagazinOnline.Domeniu.Abstract
{
    public interface IProcesareComanda
    {
        void ProcesareComanda(Cos cos, DetaliiCumparaturi detaliiCumparaturi);
    }
}
