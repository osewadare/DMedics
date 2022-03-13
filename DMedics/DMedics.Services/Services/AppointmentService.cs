using DMedics.Core.Entities;
using DMedics.Repository.Repository;
using DMedics.Services.APIModels;
using DMedics.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.Services
{
    public class AppointmentService : IAppointmentService
    {

        private IBaseRepository<Appointment> _appointmentRepo;
        private IBaseRepository<AppointmentType> _appointmentTypeRepo;

        public AppointmentService(IBaseRepository<Appointment> appointmentRepo,  IBaseRepository<AppointmentType> appointmentTypeRepo)
        {
            _appointmentRepo = appointmentRepo;
            _appointmentTypeRepo = appointmentTypeRepo;
        }

        public List<CreatedAppointmentResponseModel> GetCreatedAppointmentDates()
        {
            try
            {
                Expression<Func<Appointment, bool>> expression = x => x.AppointmentStatus == Core.Enums.AppointmentStatus.Created;
                var createdApppointments = _appointmentRepo.Find(expression).ToList();
                var result = createdApppointments.Select(x => new CreatedAppointmentResponseModel
                {
                    AppointmentDateTime = x.AppointmentTime,
                    AppointmentId = x.AppointmentId.ToString()
                }).ToList();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<AppointmentTypeResponseModel> GetAvailableAppointmentTypes()
        {
            try
            {
                var appointmentTypes = _appointmentTypeRepo.GetAll().ToList();
                var result = appointmentTypes.Select(x => new AppointmentTypeResponseModel
                {
                    AppointmentTypeId = x.AppointmentTypeId,
                    TypeDescription = x.TypeDescription,
                    TypeTitle = x.TypeTitle
                }).ToList();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
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
