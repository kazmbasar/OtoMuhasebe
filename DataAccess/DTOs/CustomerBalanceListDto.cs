using Domain.Entities;

namespace DataAccess.DTOs
{
    public class CustomerBalanceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Balance { get; set; }
    }
}
