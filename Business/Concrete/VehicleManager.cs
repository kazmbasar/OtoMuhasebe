using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public void Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetAll();
        }

        public Vehicle GetById(int id)
        {
            return _vehicleDal.Get(c=> c.Id == id);
        }

        public List<Vehicle> GetByPlateNumber(string plateNumber)
        {
            List<Vehicle> list = new List<Vehicle>();
            list = _vehicleDal.GetAll();
            foreach (Vehicle vehicle in list)
            {
                list.Where(c=>c.Plate.Contains(plateNumber)).ToList().Add(vehicle);
            }
            return list;
        }

        public void Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
        }

        public List<VehicleDto> VehicleList()
        {
            return _vehicleDal.VehicleList();
        }
    }
}
