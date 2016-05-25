namespace MagazinOnline.Domeniu.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MagazinOnline.Domeniu.Concret.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MagazinOnline.Domeniu.Concret.EFDbContext context)
        {
            
        }
    }
}
