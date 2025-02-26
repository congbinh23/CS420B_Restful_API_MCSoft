using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.VM;

namespace CS420B_RestfulApi.Repository.IRepository
{
    public interface IStaff
    {
        List<StaffVM> GetAll();
        StaffVM GetById(int id);
        StaffVM Add(StaffModule staffModule);
        void Update(StaffVM staffVM);
        void Delete(int id);
    }
}
