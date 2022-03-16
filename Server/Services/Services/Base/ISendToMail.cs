﻿using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Base
{
    public interface ISendToMail
    {
        Task SendToMailAsync(MailRequest mailRequest);
    }
}
