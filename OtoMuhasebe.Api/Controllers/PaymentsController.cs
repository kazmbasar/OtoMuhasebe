using Business.Abstract;
using Domain.Entities;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OtoMuhasebe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(int customerId)
        {
            var result = _paymentService.GetByCustomer(customerId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(PaymentAddDto paymentDto)
        {
            var payment = new Payment
            {
                CustomerId = paymentDto.CustomerId,
                Amount = paymentDto.Amount,
                Date = paymentDto.Date,
                Description = paymentDto.Description
            };
            _paymentService.Add(payment);
            return Ok(payment);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null) return NotFound();
            _paymentService.Delete(payment);
            return Ok();
        }
    }
}
