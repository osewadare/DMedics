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
        IBaseResponse GetCreatedAppointmentDates(string clinicId);

        IBaseResponse GetClinics();

        IBaseResponse GetAvailableAppointmentTypes();

        IBaseResponse CreateAppointmentBookingIntent(AppointmentRequestModel appointment);

        IBaseResponse UpdateAppointmentPaymentStatus(string paymentIntent, string redirectStatus);

        IBaseResponse GetAppointment(string appointmentReference);

        //Sprint 2
        IBaseResponse CreateAppointment(int AppointmentTypeId, int AppointmentId);

        IBaseResponse UpdateAppointment(int AppointmentId);


    }
}
