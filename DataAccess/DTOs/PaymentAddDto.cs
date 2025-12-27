using System;

namespace DataAccess.DTOs
{
    public class PaymentAddDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
