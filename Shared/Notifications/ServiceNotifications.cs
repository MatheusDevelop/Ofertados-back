using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Notifications
{
    public class ServiceNotifications
    {
        public List<string> ValidationMessages { get; set; }
        public bool Invalid { get { return ValidationMessages.Count > 0; } }
    }
}
