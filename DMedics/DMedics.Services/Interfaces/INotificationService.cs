using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.Interfaces
{
    public interface INotificationService
    {
        void SendEmail(string toEmail, string subject, string messageContent);

        void SendTextMessage(string phoneNumber, string messageContent);
        
    }
}
