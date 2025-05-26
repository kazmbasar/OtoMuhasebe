using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);
        List<Vehicle> GetAll();
        Vehicle GetById(int id);

        List<Vehicle> GetByPlateNumber(string plateNumber);
        List<VehicleDto> VehicleList();
        List<VehicleDto> GetByCustomerId(int customerId);
        
    }
}
