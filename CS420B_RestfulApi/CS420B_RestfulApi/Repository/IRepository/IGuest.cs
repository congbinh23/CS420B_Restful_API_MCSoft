using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IGuest
    {
        List<GuestVM> GetAll();
        GuestVM GetById(int id);
        GuestVM Add(GuestModule guestModule);
        void Update(GuestVM guestVM);
        void Delete(int id);
    }
}
