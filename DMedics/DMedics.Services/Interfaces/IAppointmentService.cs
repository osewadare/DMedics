using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMedics.Core.Entities;
using DMedics.Services.APIModels;

namespace DMedics.Services.Interfaces
{
   public interface IAppointmentService
    {


        //Assumption - appointments are created for specific clinics but all appointment types are available in all clcinics
        List<CreatedAppointmentResponseModel> GetCreatedAppointmentDates(string clinicId);

        //create, get, book, update, cancel       
        List<AppointmentTypeResponseModel> GetAvailableAppointmentTypes();

        bool CreateAppointmentBookingIntent(AppointmentRequestModel appointment);

        BookedAppointmentResponseModel GetAppointment(int AppointmentId);



        //Sprint 2
        bool CreateAppointment(int AppointmentTypeId, int AppointmentId);

        Appointment UpdateAppointment(int AppointmentId);

    }
}
