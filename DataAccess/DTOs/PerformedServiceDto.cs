using System;

namespace DataAccess.DTOs
{
    public class PerformedServiceDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Plate { get; set; }
        public string CustomerName { get; set; }
    }
}
