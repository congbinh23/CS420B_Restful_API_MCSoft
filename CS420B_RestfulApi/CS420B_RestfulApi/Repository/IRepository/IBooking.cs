using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IBooking
    {
        List<BookingVM> GetAll();
        BookingVM GetById(Guid id);
        BookingVM Add(BookingModule bookingModule);
        void Update(BookingVM bookingVM);
        void Delete(Guid id);
    }
}
