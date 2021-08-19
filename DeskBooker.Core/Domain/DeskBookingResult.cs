namespace DeskBooker.Core.Domain
{
    public class DeskBookingResult : DeskBookkingBase
    {
        public DeskBookingResultCode Code { get; set; }
        public int? DeskBookingId { get; set; }
    }
}