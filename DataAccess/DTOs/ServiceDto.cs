using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Aciklama { get; set; }

        public decimal Fiyat { get; set; }
    }
}
