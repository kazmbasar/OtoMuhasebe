using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
