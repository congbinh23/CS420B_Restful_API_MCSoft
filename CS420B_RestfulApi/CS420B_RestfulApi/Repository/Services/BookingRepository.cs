using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.Services
{
    public class BookingRepository : IBooking
    {
        private readonly ApiContext _context;
        public BookingRepository(ApiContext context) {
            _context = context;
        }
        public List<BookingVM> GetAll()
        {
            var bookings = _context.Bookings.Select(opt => new BookingVM
            {
                BookingID = opt.BookingID,
                GuestID = opt.GuestID??0,
                RoomNumber = opt.RoomNumber ?? 0,
                CheckinTime = opt.CheckinTime,
                CheckoutTime = opt.CheckoutTime,
                TotalPrice = opt.TotalPrice,
            });
            return bookings.ToList();
        }

        public BookingVM GetById(Guid id)
        {
            var bookings = _context.Bookings.SingleOrDefault(opt => opt.BookingID == id);
            if (bookings != null)
            {
                return new BookingVM
                {
                    BookingID = bookings.BookingID,
                    GuestID = bookings.GuestID ?? 0,
                    RoomNumber = bookings.RoomNumber ?? 0,
                    CheckinTime = bookings.CheckinTime,
                    CheckoutTime = bookings.CheckoutTime,
                    TotalPrice = bookings.TotalPrice,
                };
            }
            return null;
        }

        public BookingVM Add(BookingModule bookingModule)
        {
            var bookings = new Booking
            {
                GuestID = bookingModule.GuestID,
                RoomNumber = bookingModule.RoomNumber,
                CheckinTime = bookingModule.CheckinTime,
                CheckoutTime = bookingModule.CheckoutTime,
                TotalPrice = bookingModule.TotalPrice,
            };

            _context.Bookings.Add(bookings);
            _context.SaveChanges();

            return new BookingVM
            {
                BookingID = bookings.BookingID,
                GuestID = bookings.GuestID ?? 0,
                RoomNumber = bookings.RoomNumber ?? 0,
                CheckinTime = bookings.CheckinTime,
                CheckoutTime = bookings.CheckoutTime,
                TotalPrice = bookings.TotalPrice,
            };
            
        }

        public void Delete(Guid id)
        {
            var bookings = _context.Bookings.SingleOrDefault(opt => opt.BookingID == id);
            if (bookings != null)
            {
                _context.Bookings.Remove(bookings);
                _context.SaveChanges();
            }
        }

        
        public void Update(BookingVM bookingVM)
        {
            var bookings = _context.Bookings.SingleOrDefault(opt => opt.BookingID == bookingVM.BookingID);
            if (bookings != null) {
                bookings.BookingID = bookingVM.BookingID;
                bookings.GuestID = bookingVM.GuestID;
                bookings.RoomNumber = bookingVM.RoomNumber;
                bookings.CheckinTime = bookingVM.CheckinTime;
                bookings.CheckoutTime = bookingVM.CheckoutTime;
                bookings.TotalPrice = bookingVM.TotalPrice;
                _context.SaveChanges();
            }
        }
    }
}
