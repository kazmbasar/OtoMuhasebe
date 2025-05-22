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
    public class ITServiceManager : ITreatmentService
    {
        //T means Treatment in here
        private readonly ITServiceDal _tServiceDal;

        public ITServiceManager(ITServiceDal tServiceDal)
        {
            _tServiceDal = tServiceDal;
        }
        public void Add(Service service)
        {
            _tServiceDal.Add(service);

        }

        public void Delete(Service service)
        {
            _tServiceDal.Delete(service);
        }

        public List<Service> GetAll()
        {
            return _tServiceDal.GetAll();
        }

        public Service GetById(int id)
        {
            return _tServiceDal.Get(c=>c.Id == id);
        }

        public List<ServiceDto> ListServices()
        {
            return _tServiceDal.ListServices();
        }

        public void Update(Service service)
        {
            _tServiceDal.Update(service);
        }
    }
}
