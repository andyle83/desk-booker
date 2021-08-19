using DeskBooker.Core.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DeskBooker.Web.Pages
{
    [TestClass]
    public class BookDeskModelTests
    {
        [TestMethod]
        public void ShouldCallBookDeskMethodOfProcessor()
        {
            var deskBookingRequestProcessorMock = new Mock<IDeskBookingRequestProcessor>();

            // Arrange
            var bookDeskModel = new BookDeskModel(deskBookingRequestProcessorMock.Object)
            {
                DeskBookingRequest = new Core.Domain.DeskBookingRequest()
            };

            // Act
            bookDeskModel.OnPost();

            // Verify
            deskBookingRequestProcessorMock.Verify(x => x.BookDesk(bookDeskModel.DeskBookingRequest), Times.Once);
        }
    }
}