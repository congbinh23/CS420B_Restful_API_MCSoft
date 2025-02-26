using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IRoom
    {
        List<RoomVM> GetAll();
        RoomVM GetById(int id);
        RoomVM Add(RoomModule RoomModule);
        void Update(RoomVM roomVM);
        void Delete(int id);
    }
}
