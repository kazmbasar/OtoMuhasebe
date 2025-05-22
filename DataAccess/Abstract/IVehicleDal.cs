using DataAccess.DTOs;
using DataAccess.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IVehicleDal : IEntityRepository<Vehicle>
    {
        List<VehicleDto> VehicleList();
    }
}
