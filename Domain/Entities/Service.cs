using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service:IEntity
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        
    }
}
