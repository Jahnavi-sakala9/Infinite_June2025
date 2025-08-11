using System;
namespace MiniProject_RRS
{
    public class BookingService
    {
        private readonly BookingRepo _repo = new BookingRepo();

        public void Search(string source, string destination)
        {
            var trainRepo = new TrainRepo();
            trainRepo.Search(source, destination);
        }

        public void Book(int userId, int trainId, string classCode, int quantity, DateTime travelDate)
        {
            _repo.Book(userId, trainId, classCode, quantity, travelDate);
        }

        public void MyBookings(int userId)
        {
            _repo.MyBookings(userId);
        }

        public void Cancel(int bookingId)
        {
            _repo.Cancel(bookingId);
        }
    }
}
