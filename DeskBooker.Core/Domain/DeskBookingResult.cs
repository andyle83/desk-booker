using DeskBooker.Core.Processor;
using System;

namespace DeskBooker.Core.Domain
{
    public class DeskBookingResult : DeskBookkingBase
    {
        public DeskBookingResultCode Code { get; set; }
    }
}