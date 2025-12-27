using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class InvoiceListDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Plate { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
