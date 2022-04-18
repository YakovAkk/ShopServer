using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings
{
    public class MailSettings
    {
        public string Mail { get; set; } = "akovasko@gmail.com";
        public string DisplayName { get; set; } = "Yakov Comp";
        public string Password { get; set; } = "123qweasd___";
        public string Host { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
    }
}
