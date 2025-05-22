using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InvoiceDetail:IEntity
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Service Service { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
