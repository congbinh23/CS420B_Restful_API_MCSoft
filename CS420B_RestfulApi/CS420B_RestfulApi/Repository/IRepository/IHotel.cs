using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IHotel
    {
        List<HotelVM> GetAll();
        HotelVM GetById(int id);
        HotelVM Add(HotelModule hotelModule);
        void Update(HotelVM hotelVM);
        void Delete(int id);
    }
}
