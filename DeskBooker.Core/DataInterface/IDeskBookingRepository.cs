using DeskBooker.Core.Domain;

namespace DeskBooker.Core.DataInterface
{
    public interface IDeskBookingRepository
    {
        DeskBooking Save(DeskBooking deskBooking);
    }
}