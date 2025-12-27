using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITreatmentService
    {
        void Add(Service service);
        void Update(Service service);
        void Delete(Service service);
        List<Service> GetAll();
        Service GetById(int id);
        List<ServiceDto> ListServices();
        List<PerformedServiceDto> GetPerformedServices();
        List<PerformedServiceDto> GetPerformedServicesByCustomer(int customerId);
    }
}
