using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Printing
{
    public enum PrintJobStatus
    {
        Pending = 1,
        Processing = 2,
        Printed = 3,
        Failed = 4
    }
}
