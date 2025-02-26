using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using System.Numerics;

namespace CS420B_RestfulApi.Repository.Services
{
    public class StaffRepository : IStaff
    {
        private readonly ApiContext _context;
        public StaffRepository(ApiContext context) {
            _context = context;
        }
        public List<StaffVM> GetAll()
        {
            var staffs = _context.Staffs.Select(opt => new StaffVM
            {
                StaffID = opt.StaffID,
                HotelID = opt.HotelID??0,
                FirstName = opt.FirstName,
                LastName = opt.LastName,
                Position = opt.Position,
                Salary = opt.Salary,
                DateOfBirth = opt.DateOfBirth,
                Phone = opt.Phone,
                Email = opt.Email,
                HireDate = opt.HireDate,
            });
            return staffs.ToList();
        }

        public StaffVM GetById(int id)
        {
            var staffs = _context.Staffs.SingleOrDefault(opt => opt.StaffID == id);
            if (staffs != null)
            {
                return new StaffVM
                {
                    StaffID = staffs.StaffID,
                    HotelID = staffs.HotelID ?? 0,
                    FirstName = staffs.FirstName,
                    LastName = staffs.LastName,
                    Position = staffs.Position,
                    Salary = staffs.Salary,
                    DateOfBirth = staffs.DateOfBirth,
                    Phone = staffs.Phone,
                    Email = staffs.Email,
                    HireDate = staffs.HireDate,
                };
            }
            return null;
        }

        public StaffVM Add(StaffModule staffModule)
        {
            var staff_info = new Staff
            {   
                HotelID = staffModule.HotelID ,
                FirstName = staffModule.FirstName,
                LastName = staffModule.LastName,
                Position = staffModule.Position,
                Salary = staffModule.Salary,
                DateOfBirth = staffModule.DateOfBirth,
                Phone = staffModule.Phone,
                Email = staffModule.Email,
                HireDate = staffModule.HireDate,
            };

            _context.Staffs.Add(staff_info);
            _context.SaveChanges();

            return new StaffVM
            {
                StaffID = staff_info.StaffID,
                HotelID = staff_info.HotelID ?? 0,
                FirstName = staff_info.FirstName,
                LastName = staff_info.LastName,
                Position = staff_info.Position,
                Salary = staff_info.Salary,
                DateOfBirth = staff_info.DateOfBirth,
                Phone = staff_info.Phone,
                Email = staff_info.Email,
                HireDate = staff_info.HireDate,
            };
        }

        public void Delete(int id)
        {
            var staffs = _context.Staffs.SingleOrDefault(opt => opt.StaffID == id);
            if (staffs != null)
            {
                _context.Staffs.Remove(staffs);
                _context.SaveChanges();
            }
        }

        
        public void Update(StaffVM staffVM)
        {
            var staffs = _context.Staffs.SingleOrDefault(opt => opt.StaffID == staffVM.StaffID);
            if (staffs != null)
            {
                staffs.StaffID = staffVM.StaffID;
                staffs.HotelID = staffVM.HotelID;
                staffs.FirstName = staffVM.FirstName;
                staffs.LastName = staffVM.LastName;
                staffs.Position = staffVM.Position;
                staffs.Salary = staffVM.Salary;
                staffs.DateOfBirth = staffVM.DateOfBirth;
                staffs.Phone = staffVM.Phone;
                staffs.Email = staffVM.Email;
                staffs.HireDate = staffVM.HireDate;
                _context.SaveChanges();
            };
        }
    }
}
