using System;

namespace Domain.Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
    }
}
