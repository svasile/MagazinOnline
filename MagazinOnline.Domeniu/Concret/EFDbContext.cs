using MagazinOnline.Domeniu.Entitati;
using System.Data.Entity;

namespace MagazinOnline.Domeniu.Concret
{
    public class EFDbContext : DbContext
    {
        public DbSet<Produs> Produse {get;set;}
        public DbSet<Utilizator> Utilizatori { get; set; }
    }
}
