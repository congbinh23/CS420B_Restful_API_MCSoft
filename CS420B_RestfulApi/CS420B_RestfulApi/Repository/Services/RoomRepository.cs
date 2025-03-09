using Azure.Core;
using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CS420B_RestfulApi.Repository.Services
{
    public class RoomRepository : IRoom
    {
        private readonly ApiContext _context;
        public RoomRepository(ApiContext context) {
            _context = context;
        }
        public List<RoomVM> GetAll()
        {
            var rooms = _context.Rooms.Select(opt => new RoomVM
            {
                RoomNumber = opt.RoomNumber,
                HotelID = opt.HotelID ?? 0,
                TypeID = opt.TypeID ?? 0,
                status = opt.status,
            });
            return rooms.ToList();
        }

        public RoomVM GetById(int id)
        {
            var rooms = _context.Rooms.SingleOrDefault(opt => opt.RoomNumber == id);
            if (rooms != null) {
                return new RoomVM {
                    RoomNumber = rooms.RoomNumber,
                    HotelID = rooms.HotelID ?? 0,
                    TypeID = rooms.TypeID ?? 0,
                    status = rooms.status,
                };
            }
            return null;
        }

        public RoomVM Add(RoomModule roomModule)
        {
            var rooms = new Room
            {
                HotelID = roomModule.HotelID,
                TypeID = roomModule.TypeID,
                status = roomModule.status,
            };
            _context.Rooms.Add(rooms);
            _context.SaveChanges();

            return new RoomVM
            {
                RoomNumber = rooms.RoomNumber,
                HotelID = rooms.HotelID ?? 0,
                TypeID = rooms.TypeID ?? 0,
                status = rooms.status,
            };
        }

        public void Delete(int id)
        {
            var rooms = _context.Rooms.SingleOrDefault(opt => opt.RoomNumber == id);
            if (rooms != null)
            {
                _context.Rooms.Remove(rooms);
                _context.SaveChanges();
            }
        }

        
        public void Update(RoomVM roomVM)
        {
            var rooms = _context.Rooms.SingleOrDefault(opt => opt.RoomNumber == roomVM.RoomNumber);
            if (rooms != null)
            {
                rooms.RoomNumber = roomVM.RoomNumber;
                rooms.HotelID = roomVM.HotelID;
                rooms.TypeID = roomVM.TypeID;
                rooms.status = roomVM.status;
                _context.SaveChanges();
            }
            
        }
    }
}
