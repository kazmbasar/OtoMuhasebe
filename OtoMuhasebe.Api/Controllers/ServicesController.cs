using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoMuhasebe.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly ITreatmentService _treatmentService;

    public ServicesController(ITreatmentService treatmentService)
    {
        _treatmentService = treatmentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _treatmentService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _treatmentService.GetById(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("dto")]
    public IActionResult ListServices()
    {
        var result = _treatmentService.ListServices();
        return Ok(result);
    }

    [HttpGet("performed")]
    public IActionResult GetPerformedServices()
    {
        var result = _treatmentService.GetPerformedServices();
        return Ok(result);
    }

    [HttpGet("performed/customer/{customerId}")]
    public IActionResult GetPerformedServicesByCustomer(int customerId)
    {
        var result = _treatmentService.GetPerformedServicesByCustomer(customerId);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Service service)
    {
        _treatmentService.Add(service);
        return Ok(service);
    }

    [HttpPut]
    public IActionResult Update(Service service)
    {
        _treatmentService.Update(service);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var service = _treatmentService.GetById(id);
            if (service == null) return NotFound();
            _treatmentService.Delete(service);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(Service service)
    {
        _treatmentService.Delete(service);
        return Ok();
    }
}
