using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using System;

namespace CS420B_RestfulApi.Repository.Services
{
    public class RoomTypeRepository : IRoomType
    {
        private readonly ApiContext _context;
        public RoomTypeRepository(ApiContext context) {
            _context = context;
        }
        public List<RoomTypeVM> GetAll()
        {
            var roomtypes = _context.RoomTypes.Select(opt => new RoomTypeVM
            {
                TypeID = opt.TypeID,
                Name = opt.Name,
                Description = opt.Description,
                PricePerNight = opt.PricePerNight,
                Capacity = opt.Capacity,
            });
            return roomtypes.ToList();
        }

        public RoomTypeVM GetById(int id)
        {
            var roomtypes = _context.RoomTypes.SingleOrDefault(opt =>  opt.TypeID == id);
            if (roomtypes != null) {
                return new RoomTypeVM
                {
                    TypeID = roomtypes.TypeID,
                    Name = roomtypes.Name,
                    Description = roomtypes.Description,
                    PricePerNight = roomtypes.PricePerNight,
                    Capacity = roomtypes.Capacity,
                };
            }
            return null;
        }

        public RoomTypeVM Add(RoomTypeModule roomTypeModule)
        {
            var roomtypes = new RoomType
            {
                Name = roomTypeModule.Name,
                Description = roomTypeModule.Description,
                PricePerNight = roomTypeModule.PricePerNight,
                Capacity = roomTypeModule.Capacity,
            };
            _context.RoomTypes.Add(roomtypes);
            _context.SaveChanges();

            return new RoomTypeVM {
                Name = roomtypes.Name,
                Description = roomtypes.Description,
                PricePerNight = roomtypes.PricePerNight,
                Capacity = roomtypes.Capacity,
            };
        }

        public void Delete(int id)
        {
            var roomtypes = _context.RoomTypes.SingleOrDefault(opt => opt.TypeID == id);
            if (roomtypes != null) {
                _context.RoomTypes.Remove(roomtypes);
                _context.SaveChanges();
            }
        }

        public void Update(RoomTypeVM roomTypeVM)
        {
            var roomtypes = _context.RoomTypes.SingleOrDefault(opt => opt.TypeID == roomTypeVM.TypeID);
            if (roomtypes != null) {
                roomtypes.TypeID = roomTypeVM.TypeID;
                roomtypes.Name = roomTypeVM.Name;
                roomtypes.Description = roomTypeVM.Description;
                roomtypes.PricePerNight = roomTypeVM.PricePerNight;
                roomtypes.Capacity = roomTypeVM.Capacity;
                _context.SaveChanges();
            }
        }
    }
}
