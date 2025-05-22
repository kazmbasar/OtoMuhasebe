using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Musteri_Adi { get; set; }
        public string Arac_Plaka { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Toplam_Tutar { get; set; }
    }
}
