﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMedics.Services.Interfaces
{
    public interface INotificationService
    {
        //sent
        GCNotificationStatus Status (string status);
    }
}