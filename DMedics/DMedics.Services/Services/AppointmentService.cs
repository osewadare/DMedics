using DMedics.Core.Entities;
using DMedics.Repository.Repository;
using DMedics.Services.APIModels;
using DMedics.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.Services
{
    public class AppointmentService : IAppointmentService
    {

        private IBaseRepository<Appointment> _baseRepository;

        public AppointmentService(IBaseRepository<Appointment> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public List<CreatedAppointmentResponseModel> GetAvailableAppointmentDates()
        {
            throw new NotImplementedException();
        }

        public List<AppointmentTypeResponseModel> GetAvailableAppointmentTypes()
        {
            throw new NotImplementedException();
        }

        public bool BookAppointment(AppointmentRequestModel appointment)
        {
            throw new NotImplementedException();
        }

        public BookedAppointmentResponseModel GetAppointment(int AppointmentId)
        {
            throw new NotImplementedException();
        }

        //Sprint 2

        public bool CreateAppointment(int AppointmentTypeId, int AppointmentId)
        {
            throw new NotImplementedException();
        }

        public Appointment UpdateAppointment(int AppointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
