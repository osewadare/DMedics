using System;
namespace DMedics.Domain.Enums
{
    public enum PaymentStatus
    {
        succeeded,
        processing,
        requires_payment_method
    }
}
