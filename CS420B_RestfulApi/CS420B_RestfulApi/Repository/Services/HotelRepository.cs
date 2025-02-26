using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using CS420B_RestfulApi.Models.InputModule;

namespace CS420B_RestfulApi.Repository.Services
{
    public class HotelRepository : IHotel
    {
        private readonly ApiContext _context;
        public HotelRepository(ApiContext context)
        {
            _context = context;
        }

        public List<HotelVM> GetAll()
        {
            var hotels = _context.Hotels.Select(opt => new HotelVM
            {
                HotelID = opt.HotelID,
                Name = opt.Name,
                Address = opt.Address,
                Email = opt.Email,
                Number = opt.Number,
                Stars = opt.Stars,
                CheckinTime = opt.CheckinTime,
                CheckoutTime = opt.CheckoutTime,
            });
            return hotels.ToList();
        }

        public HotelVM GetById(int id)
        {
            var hotels = _context.Hotels.SingleOrDefault(opt => opt.HotelID == id);
            if (hotels != null) {
                return new HotelVM
                {
                    HotelID = hotels.HotelID,
                    Name = hotels.Name,
                    Address = hotels.Address,
                    Email = hotels.Email,
                    Number = hotels.Number,
                    Stars = hotels.Stars,
                    CheckinTime = hotels.CheckinTime,
                    CheckoutTime = hotels.CheckoutTime,
                };
            }
            return null;
        }

        public HotelVM Add(HotelModule hotelModule)
        {
            var hotel_info = new Hotel
            {
                Name = hotelModule.Name,
                Address = hotelModule.Address,
                Email = hotelModule.Email,
                Number = hotelModule.Number,
                Stars = hotelModule.Stars,
                CheckinTime = hotelModule.CheckinTime,
                CheckoutTime = hotelModule.CheckoutTime,
            };

            _context.Hotels.Add(hotel_info);
            _context.SaveChanges();

            return new HotelVM
            {
                HotelID = hotel_info.HotelID,
                Name = hotel_info.Name,
                Address = hotel_info.Address,
                Email = hotel_info.Email,
                Number = hotel_info.Number,
                Stars = hotel_info.Stars,
                CheckinTime = hotel_info.CheckinTime,
                CheckoutTime = hotel_info.CheckoutTime,
            };
        }

        public void Delete(int id)
        {
            var hotels = _context.Hotels.SingleOrDefault(opt => opt.HotelID == id);
            if (hotels != null)
            {
                _context.Hotels.Remove(hotels);
                _context.SaveChanges();
            }
        }

        public void Update(HotelVM hotelVM)
        {
            var hotels = _context.Hotels.SingleOrDefault(opt => opt.HotelID == hotelVM.HotelID);
            if (hotels != null)
            {
                hotels.HotelID = hotelVM.HotelID;
                hotels.Name = hotelVM.Name;
                hotels.Address = hotelVM.Address;
                hotels.Email = hotelVM.Email;
                hotels.Number = hotelVM.Number;
                hotels.Stars = hotelVM.Stars;
                hotels.CheckinTime = hotelVM.CheckinTime;
                hotels.CheckoutTime = hotelVM.CheckoutTime;
                _context.SaveChanges();
            }
        }
    }
}
