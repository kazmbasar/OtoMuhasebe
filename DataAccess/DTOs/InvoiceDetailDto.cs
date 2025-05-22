using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public string Hizmet_Adi { get; set; }
        public decimal Birim_Fiyat { get; set; }
        public int Adet { get; set; }
        public decimal Tutar => Birim_Fiyat * Adet;
    }
}
