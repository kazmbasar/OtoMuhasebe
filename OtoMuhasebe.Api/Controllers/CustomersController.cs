using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoMuhasebe.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _customerService.GetListWithBalance();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _customerService.GetCustomerById(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        _customerService.Add(customer);
        return Ok(customer);
    }

    [HttpPut]
    public IActionResult Update(Customer customer)
    {
        _customerService.Update(customer);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();
            _customerService.Delete(customer);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(Customer customer)
    {
        _customerService.Delete(customer);
        return Ok();
    }
}
