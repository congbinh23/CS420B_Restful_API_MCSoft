using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IRoomType
    {
        List<RoomTypeVM> GetAll();
        RoomTypeVM GetById(int id);
        RoomTypeVM Add(RoomTypeModule roomTypeModule);
        void Update(RoomTypeVM roomTypeVM);
        void Delete(int id);
    }
}
