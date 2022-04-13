using DMedics.Domain.Entities;
using DMedics.Repository.Repository;
using DMedics.Services.APIModels;
using DMedics.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DMedics.Domain.Enums;
using DMedics.Services.Constants;
using Hangfire;

namespace DMedics.Services.Services
{
    public class AppointmentService : IAppointmentService
    {

        private IBaseRepository<Appointment> _appointmentRepo;
        private IBaseRepository<Clinic> _clinicsRepo;
        private IBaseRepository<AppointmentType> _appointmentTypeRepo;
        private ILogger<AppointmentService> _logger;
        private IPaymentService _paymentService;
        private INotificationService _notificationService;

        public AppointmentService(IBaseRepository<Appointment> appointmentRepo,
            IBaseRepository<AppointmentType> appointmentTypeRepo,
            ILogger<AppointmentService> logger, IPaymentService paymentService,
            IBaseRepository<Clinic> clinicsRepo,
            INotificationService notificationService)
        {
            _notificationService = notificationService;
            _appointmentRepo = appointmentRepo;
            _appointmentTypeRepo = appointmentTypeRepo;
            _logger = logger;
            _paymentService = paymentService;
            _clinicsRepo = clinicsRepo;
        }



        public BaseResponse GetAvailableAppointmentTypes()
        {
            try
            {
                var appointmentTypes = _appointmentTypeRepo.GetAll(false).ToList();
                var appointmentTypesModel = appointmentTypes.Select(x => new AppointmentTypeModel
                {
                    AppointmentTypeId = x.AppointmentTypeId,
                    TypeDescription = x.TypeDescription,
                    TypeTitle = x.TypeTitle
                }).ToList();
                var result = new AppointmentTypeResponseModel
                {
                    appointmentTypes = appointmentTypesModel,
                    StatusCode = StatusCodes.Successful,
                    IsSuccessful = true
                };
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError("GetAvailableAppointmentTypes Exception: e", e.Message);
                return null;
            }
        }

        public BaseResponse GetClinics()
        {
            try
            {
                var clinics = _clinicsRepo.GetAll(false).ToList();
                var clinicsModel = clinics.Select(x => new ClinicsModel
                {
                    ClinicId= x.ClinicId,
                    Clinic = $"{x.ClinicName} {x.ClinicAddress}"
                }).ToList();
                var result = new ClinicsResponseModel
                {
                    clinicsResponse = clinicsModel,
                    StatusCode = StatusCodes.Successful,
                    IsSuccessful = true
                };
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError("GetClinics Exception: e", e.Message);
                return null;
            }
        }

        public BaseResponse GetCreatedAppointmentDates(string clinicId)
        {
            try
            {
                Expression<Func<Appointment, bool>> expression = x => x.AppointmentStatus == AppointmentStatus.Created && x.Clinic.ClinicId == int.Parse(clinicId);
                var createdApppointments = _appointmentRepo.Find(expression).ToList();
                var createdAppointmentsModel = createdApppointments.Select(x => new CreatedAppointmentModel
                {
                    AppointmentDateTime = x.AppointmentTime,
                    AppointmentId = x.AppointmentId.ToString()
                }).ToList();

                var result = new CreatedAppointmentResponseModel { createdAppointmentResponseModel = createdAppointmentsModel };
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError("GetCreatedAppointmentDates Exception: e", e.Message);
                return null;
            }
        }

        public BaseResponse CreateAppointmentBookingIntent(AppointmentRequestModel appointment)
        {
            try
            {
                var appointmentId = int.Parse(appointment.AppointmentId);
                Expression<Func<Appointment, bool>> expression = x => x.AppointmentId == appointmentId;
                var createdApppointment = _appointmentRepo.FindandInclude(expression, true).FirstOrDefault();
                var appointmentNotAvailable = (createdApppointment.AppointmentStatus != AppointmentStatus.Created);
                if (appointmentNotAvailable)
                {
                    return new BaseResponse
                    {
                        IsSuccessful = false,
                        Message = "Appointment not found",
                        StatusCode = StatusCodes.Successful
                    };
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
                        Gender = (Gender)Enum.Parse(typeof(Gender), appointment.Gender),
                        PostCode = appointment.PostCode,
                        ReferralSource = ""
                    };
                    //   createdApppointment.AppointmentStatus = AppointmentStatus.Booked;
                    createdApppointment.PaymentSecret = clientSecret;
                    createdApppointment.Customer = customer;

                    createdApppointment.AppointmentTypeId = int.Parse(appointment.AppointmentTypeId);
                    _appointmentRepo.Update(createdApppointment);
                    return new BaseResponse
                    {
                        StatusCode = StatusCodes.Successful,
                        IsSuccessful = true,
                        Message = clientSecret
                    };
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("GetCreatedAppointmentDates Exception: e", e.Message);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.GeneralError,
                    IsSuccessful = false,
                    Message = "Sorry you request could not be completed. Please try again"
                };
            }
        }

        public BaseResponse GetAppointment(string appointmentReference)
        {
            try
            {
                //Lambda expression tree from a delegate that checks if appointment reference is matched
                Expression <Func<Appointment, bool>> expression = x => x.AppointmentReference == appointmentReference;
                var appointment = _appointmentRepo.FindandInclude(expression, true).FirstOrDefault();
                if (appointment == null)
                {
                    return new BaseResponse
                    {
                        StatusCode = StatusCodes.Successful,
                        IsSuccessful = false,
                        Message = "No Appointment found"
                    };
                }
                var response = new BookedAppointmentResponseModel
                {
                    AppointmentDateTime = appointment.AppointmentTime.ToString(),
                    AppointmentReference = appointment.AppointmentReference,
                    Clinic = appointment.Clinic.ClinicName,
                    FirstName = appointment.Customer.FirstName,
                    IsSuccessful = true,
                    StatusCode = StatusCodes.Successful,
                    Message = "success"
                };

                return response;
                   
            }
            catch(Exception e)
            {
                _logger.LogError("GetCreatedAppointmentDates Exception: e", e.Message);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.GeneralError,
                    IsSuccessful = false,
                    Message = "Sorry you request could not be completed. Please try again"
                };
            }
        }


        public BaseResponse GetAppointments()
        {
            try
            {

                var appointments = _appointmentRepo.GetAll(true).ToList();

                var response = new AppointmentsViewModel
                {
                    appointments = appointments.Select(x => new AppointmentsModel
                    {
                        AppointmentId = x.AppointmentId,
                        AppointmentStatus = x.AppointmentStatus.ToString(),
                        AppointmentReference = x.AppointmentReference,
                        AppointmentTime = x.AppointmentTime,
                        AppointmentType = x.AppointmentType?.TypeTitle,
                        ClinicName = x.Clinic.ClinicName,
                        CustomerName = $"{x.Customer?.FirstName} {x.Customer?.LastName}",
                        DoctorName = $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}"
                    }).ToList(),
                    StatusCode = StatusCodes.Successful,
                    IsSuccessful = true,
                    Message = "success"
                };
                return response;

            }
            catch (Exception e)
            {
                _logger.LogError("GetAppointments Exception: e", e.Message);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.GeneralError,
                    IsSuccessful = false,
                    Message = "Sorry you request could not be completed. Please try again"
                };
            }
        }


        public BaseResponse CreateAppointment(CreateAppointmentRequestModel createAppointmentRequestModel)
        {
            try
            {
                var appointment = new Appointment
                {
                    AppointmentStatus = AppointmentStatus.Created,
                    ClinicId = int.Parse(createAppointmentRequestModel.ClinicId),
                    ApplicationUserId = createAppointmentRequestModel.UserId,
                    AppointmentTime = DateTime.Parse(createAppointmentRequestModel.AppointmentDateTime),
                };
                 _appointmentRepo.Add(appointment);
                    return new BaseResponse
                    {
                        StatusCode = StatusCodes.Successful,
                        IsSuccessful = true,
                        Message = "success"
                    };
            }
            catch (Exception e)
            {
                _logger.LogError("CreateAppointment Exception: e", e.Message);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.GeneralError,
                    IsSuccessful = false,
                    Message = "Sorry you request could not be completed. Please try again"
                };
            }
        }

        public BaseResponse UpdateAppointment(UpdateAppointmentRequestModel requestModel)
        {
            try
            {
                var appointmentId = int.Parse(requestModel.AppointmentId);
                Expression<Func<Appointment, bool>> expression = x => x.AppointmentId == appointmentId;
                var createdApppointment = _appointmentRepo.FindandInclude(expression, true).FirstOrDefault();
                createdApppointment.ClinicId = int.Parse(requestModel.ClinicId);
                createdApppointment.ApplicationUserId = requestModel.UserId;
                _appointmentRepo.Update(createdApppointment);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.Successful,
                    IsSuccessful = true,
                    Message = "success"
                };
            }
            catch (Exception e)
            {
                _logger.LogError("UpdateAppointment Exception: e", e.Message);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.GeneralError,
                    IsSuccessful = false,
                    Message = "Sorry you request could not be completed. Please try again"
                };
            }
        }

        public BaseResponse UpdateAppointmentPaymentStatus(string paymentIntent, string redirectStatus)
        {
            try
            {
                Expression<Func<Appointment, bool>> expression = x => x.PaymentSecret == paymentIntent;
                var appointment = _appointmentRepo.FindandInclude(expression, true).FirstOrDefault();
                if (appointment == null)
                {
                    return new BaseResponse
                    {
                        StatusCode = StatusCodes.Successful,
                        IsSuccessful = false,
                        Message = "No Appointment found"
                    };
                }
                appointment.AppointmentStatus = (redirectStatus == PaymentStatus.succeeded.ToString()) ? AppointmentStatus.Booked :
                                                (redirectStatus == PaymentStatus.processing.ToString()) ? AppointmentStatus.PaymentProcessing :
                                                (redirectStatus == PaymentStatus.requires_payment_method.ToString()) ? AppointmentStatus.PaymentFailed :
                                                 AppointmentStatus.PaymentStatusUnknown;

                /*_notificationService.SendEmail(appointment.Customer.EmailAddress, "Booking Confirmed", $"Thank you for Booking. Find details below: \n " +
                    $"Clinic Name: {appointment.Clinic.ClinicName} " +
                    $"Appointment Time: {appointment.AppointmentTime}");

                _notificationService.SendTextMessage(appointment.Customer.PhoneNumber, $"Thank you for Booking. Find details below: \n " +
                    $"Clinic Name: {appointment.Clinic.ClinicName} " +
                    $"Appointment Time: {appointment.AppointmentTime}");*/

                var reminderDate = appointment.AppointmentTime.AddDays(-1);

                var jobId = BackgroundJob.Schedule(
                            () => _notificationService.SendTextMessage(appointment.Customer.PhoneNumber, $"Thank you for Booking. Find details below: \n " +
                    $"Clinic Name: {appointment.Clinic.ClinicName} " +
                    $"Appointment Time: {appointment.AppointmentTime}"), reminderDate);


                var bookingReference = Guid.NewGuid().ToString().Substring(0, 6);
                appointment.AppointmentReference = bookingReference;
                _appointmentRepo.Update(appointment);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.Successful,
                    IsSuccessful = true,
                    Message = bookingReference
                };

            }
            catch (Exception e)
            {
                _logger.LogError("GetCreatedAppointmentDates Exception: e", e.Message);
                return new BaseResponse
                {
                    StatusCode = StatusCodes.GeneralError,
                    IsSuccessful = false,
                    Message = "Sorry you request could not be completed. Please try again"
                };
            }
        }
    }
}
