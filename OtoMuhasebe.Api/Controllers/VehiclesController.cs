using Business.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace OtoMuhasebe.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _vehicleService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _vehicleService.GetById(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("dto")]
    public IActionResult ListVehicles()
    {
        var result = _vehicleService.VehicleList();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Add(Vehicle vehicle)
    {
        _vehicleService.Add(vehicle);
        return Ok(vehicle);
    }

    [HttpPut]
    public IActionResult Update(Vehicle vehicle)
    {
        _vehicleService.Update(vehicle);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle == null) return NotFound();
            _vehicleService.Delete(vehicle);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(Vehicle vehicle)
    {
        _vehicleService.Delete(vehicle);
        return Ok();
    }
}
