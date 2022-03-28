using System;
namespace DMedics.Domain.Enums
{
        public enum AppointmentStatus
        {
            Created,
            PaymentIntentCreated,
            Booked,
            PaymentFailed,
            PaymentProcessing,
            PaymentStatusUnknown,
            Attended,
            Cancelled,
            Unattended
        }
}
