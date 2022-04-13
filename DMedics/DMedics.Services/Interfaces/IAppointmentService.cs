using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Domain.Entities;
using DMedics.Services.APIModels;

namespace DMedics.Services.Interfaces
{
   public interface IAppointmentService
    {


        //Assumption - appointments are created for specific clinics but all appointment types are available in all clcinics
        BaseResponse GetCreatedAppointmentDates(string clinicId);

        BaseResponse GetClinics();

        BaseResponse GetAvailableAppointmentTypes();

        BaseResponse CreateAppointmentBookingIntent(AppointmentRequestModel appointment);

        BaseResponse UpdateAppointmentPaymentStatus(string paymentIntent, string redirectStatus);

        BaseResponse GetAppointment(string appointmentReference);

        BaseResponse CreateAppointment(CreateAppointmentRequestModel createAppointmentRequestModel);

        BaseResponse UpdateAppointment(UpdateAppointmentRequestModel createAppointmentRequestModel);

        BaseResponse GetAppointments();


    }
}
