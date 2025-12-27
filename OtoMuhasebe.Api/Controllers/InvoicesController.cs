using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoMuhasebe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        private readonly InvoiceDetailService _invoiceDetailService;

        public InvoicesController(InvoiceService invoiceService, InvoiceDetailService invoiceDetailService)
        {
            _invoiceService = invoiceService;
            _invoiceDetailService = invoiceDetailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _invoiceService.GetInvoiceList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _invoiceService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}/details")]
        public IActionResult GetDetails(int id)
        {
            var result = _invoiceDetailService.InvoiceDetailList(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Invoice invoice)
        {
            invoice.Date = DateTime.Now;
            _invoiceService.Add(invoice);
            return Ok(invoice);
        }

        [HttpPost("detail")]
        public IActionResult AddDetail(InvoiceDetail detail)
        {
            _invoiceDetailService.Add(detail);
            return Ok(detail);
        }

        [HttpPut]
        public IActionResult Update(Invoice invoice)
        {
            _invoiceService.UpdateInvoice(invoice);
            return Ok(invoice);
        }

        [HttpDelete("{id}/details")]
        public IActionResult DeleteDetails(int id)
        {
            _invoiceDetailService.DeleteByInvoiceId(id);
            return Ok();
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(int customerId)
        {
            var result = _invoiceService.GetByCustomerId(customerId);
            return Ok(result);
        }
    }
}
