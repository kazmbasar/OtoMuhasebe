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
        private readonly ITServiceDal _tServiceDal;
        private readonly InvoiceDetailDal _invoiceDetailDal;

        public ITServiceManager(ITServiceDal tServiceDal, InvoiceDetailDal invoiceDetailDal)
        {
            _tServiceDal = tServiceDal;
            _invoiceDetailDal = invoiceDetailDal;
        }
        public void Add(Service service)
        {
            _tServiceDal.Add(service);

        }

        public void Delete(Service service)
        {
            var usage = _invoiceDetailDal.GetAll(x => x.ServiceId == service.Id);
            if (usage != null && usage.Count > 0)
            {
                throw new InvalidOperationException("Bu işlem tanımı faturalarda kullanıldığı için silinemez. Önce ilgili fatura detaylarını silmelisiniz.");
            }
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

        public List<PerformedServiceDto> GetPerformedServices()
        {
            return _tServiceDal.GetPerformedServices();
        }

        public List<PerformedServiceDto> GetPerformedServicesByCustomer(int customerId)
        {
            return _tServiceDal.GetPerformedServicesByCustomer(customerId);
        }

        public void Update(Service service)
        {
            _tServiceDal.Update(service);
        }
    }
}
