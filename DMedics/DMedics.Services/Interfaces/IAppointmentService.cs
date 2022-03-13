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
        //create, get, book, update, cancel       
        List<AppointmentTypeResponseModel> GetAvailableAppointmentTypes();

        List<CreatedAppointmentResponseModel> GetCreatedAppointmentDates();

        bool BookAppointment(AppointmentRequestModel appointment);

        BookedAppointmentResponseModel GetAppointment(int AppointmentId);



        //Sprint 2
        bool CreateAppointment(int AppointmentTypeId, int AppointmentId);

        Appointment UpdateAppointment(int AppointmentId);

    }
}
