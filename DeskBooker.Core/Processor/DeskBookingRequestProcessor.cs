using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using System;
using System.Linq;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        private IDeskBookingRepository _deskBookingRepository;
        private IDeskRepository _deskRepository;

        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
        {
            _deskBookingRepository = deskBookingRepository;
            _deskRepository = deskRepository;
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var availableDesks = _deskRepository.GetAvailableDesks(request.Date);
            var bookingResult = Create<DeskBookingResult>(request);

            if (availableDesks.FirstOrDefault() is Desk availableDesk)
            {
                var deskBooking = Create<DeskBooking>(request);

                deskBooking.DeskId = availableDesk.Id;
                _deskBookingRepository.Save(deskBooking);

                bookingResult.DeskBookingId = deskBooking.Id;
                bookingResult.Code = DeskBookingResultCode.Success;
            }
            else
            {
                bookingResult.DeskBookingId = null;
                bookingResult.Code = DeskBookingResultCode.NoDeskAvailable;
            }

            return bookingResult;
        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookkingBase, new()

        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }
    }
}