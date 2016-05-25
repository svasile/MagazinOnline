using System;

namespace MagazinOnline.UI.Models
{
    public class InfoPaginare
    {
        public int TotalArticole { get; set; }
        public int ArticolePePagina { get; set; }
        public int PaginaCurenta { get; set; }
        public int TotalPagini
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalArticole / ArticolePePagina);
            }
        }
    }
}
