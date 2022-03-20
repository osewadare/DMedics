using DMedics.Core.Entities;
using DMedics.Repository.Repository;
using DMedics.Services.APIModels;
using DMedics.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DMedics.Core.Enums;

namespace DMedics.Services.Services
{
    public class AppointmentService : IAppointmentService
    {

        private IBaseRepository<Appointment> _appointmentRepo;
        private IBaseRepository<AppointmentType> _appointmentTypeRepo;
        private ILogger<AppointmentService> _logger;
        private PaymentService _paymentService;

        public AppointmentService(IBaseRepository<Appointment> appointmentRepo,
            IBaseRepository<AppointmentType> appointmentTypeRepo,
            ILogger<AppointmentService> logger, PaymentService paymentService)
        {
            _appointmentRepo = appointmentRepo;
            _appointmentTypeRepo = appointmentTypeRepo;
            _logger = logger;
            _paymentService = paymentService;
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
                _logger.LogError("GetAvailableAppointmentTypes Exception: e", e.Message);
                return null;
            }
        }

        public List<CreatedAppointmentResponseModel> GetCreatedAppointmentDates(string clinicId)
        {
            try
            {
                Expression<Func<Appointment, bool>> expression = x => x.AppointmentStatus == Core.Enums.AppointmentStatus.Created && x.ClinicId == int.Parse(clinicId);
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
                _logger.LogError("GetCreatedAppointmentDates Exception: e", e.Message);
                return null;
            }
        }

       

        public string CreateAppointmentBookingIntent(AppointmentRequestModel appointment)
        {
            try
            {
                Expression<Func<Appointment, bool>> expression = x => x.AppointmentId.ToString() == appointment.AppointmentId;
                var createdApppointment = _appointmentRepo.Find(expression).FirstOrDefault();
                var appointmentNotAvailable = (createdApppointment.AppointmentStatus != AppointmentStatus.Created);
                if (appointmentNotAvailable)
                {
                    return null;
                }
                else
                {
                    //Create Payment Intent

                    var clientSecret = _paymentService.CreatePaymentIntent();

                    //Store in Database 
                    var customer = new Customer
                    {
                        FirstName = appointment.FirstName,
                        LastName = appointment.LastName,
                        DOB = DateTime.Parse(appointment.DOB),
                        EmailAddress = appointment.EmailAddress,
                        PhoneNumber = appointment.PhoneNumber,
                        Gender = appointment.Gender,
                        PaymentSecret = clientSecret  
                    };

                    createdApppointment.AppointmentStatus = AppointmentStatus.Booked;
                    createdApppointment.Customer = customer;
                    createdApppointment.AppointmentTypeId = int.Parse(appointment.AppointmentTypeId);
                    createdApppointment.ClinicId = int.Parse(appointment.ClinicId);
                    _appointmentRepo.Update(createdApppointment);

                    return clientSecret;
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("GetCreatedAppointmentDates Exception: e", e.Message);
                return null;
            }
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
