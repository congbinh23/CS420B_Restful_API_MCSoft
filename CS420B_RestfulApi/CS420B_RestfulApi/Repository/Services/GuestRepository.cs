using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using System.Net;
using System.Numerics;

namespace CS420B_RestfulApi.Repository.Services
{
    public class GuestRepository : IGuest
    {
        private readonly ApiContext _context;
        public GuestRepository(ApiContext context)
        {
            _context = context;
        }

        public List<GuestVM> GetAll()
        {
            var guests = _context.Guests.Select(opt => new GuestVM {
                GuestID = opt.GuestID,
                FirstName = opt.FirstName,
                LastName = opt.LastName,
                Address = opt.Address,
                DateOfBirth = opt.DateOfBirth,
                Email = opt.Email,
                Phone = opt.Phone,
            });
            return guests.ToList();
        }

        public GuestVM GetById(int id)
        {
            var guests = _context.Guests.SingleOrDefault(opt => opt.GuestID == id);
            if (guests != null)
            {
                return new GuestVM
                {
                    GuestID = guests.GuestID,
                    FirstName = guests.FirstName,
                    LastName = guests.LastName,
                    Address = guests.Address,
                    DateOfBirth = guests.DateOfBirth,
                    Email = guests.Email,
                    Phone = guests.Phone,
                };
            }
            return null;
        }
        public GuestVM Add(GuestModule guestModule)
        {
            var guest_info = new Guest
            {
                FirstName = guestModule.FirstName,
                LastName = guestModule.LastName,
                Address = guestModule.Address,
                DateOfBirth = guestModule.DateOfBirth,
                Email = guestModule.Email,
                Phone = guestModule.Phone,
            };

            _context.Guests.Add(guest_info);
            _context.SaveChanges();

            return new GuestVM
            {
                GuestID = guest_info.GuestID,
                FirstName = guest_info.FirstName,
                LastName = guest_info.LastName,
                Address = guest_info.Address,
                DateOfBirth = guest_info.DateOfBirth,
                Email = guest_info.Email,
                Phone = guest_info.Phone,
            };
        }

        public void Delete(int id)
        {
            var guests = _context.Guests.SingleOrDefault(opt => opt.GuestID == id);
            if (guests != null)
            {   
                _context.Guests.Remove(guests);
                _context.SaveChanges();
            }
        }

        
        public void Update(GuestVM guestVM)
        {
            var guests = _context.Guests.SingleOrDefault(opt => opt.GuestID == guestVM.GuestID);
            if (guests != null)
            {
                guests.GuestID = guestVM.GuestID;
                guests.FirstName = guestVM.FirstName;
                guests.LastName = guestVM.LastName;
                guests.Address = guestVM.Address;
                guests.DateOfBirth = guestVM.DateOfBirth;
                guests.Email = guestVM.Email;
                guests.Phone = guestVM.Phone;
                _context.SaveChanges();
            };
        }
    }
}
