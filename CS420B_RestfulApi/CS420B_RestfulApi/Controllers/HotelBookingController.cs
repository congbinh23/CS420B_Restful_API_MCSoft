using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CS420B_RestfulApi.Models;
using CS420B_RestfulApi.Data;


namespace CS420B_RestfulApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        // Create/edit
        [HttpPost]
        public JsonResult CreateEdit(HotelBooking_Info booking)
        {
            var hotelbook = new HotelBooking
            {
                Id = Guid.NewGuid(),
                RoomNumber = booking.RoomNumber,
                ClientName = booking.ClientName,
            };

            _context.Bookings.Add(hotelbook);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }

        //Get
        [HttpGet]
        public JsonResult Get(Guid id) {
            var result = _context.Bookings.Find(id);

            if (result == null) {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(Guid id) {

            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }


        // Get all
        [HttpGet()]
        public JsonResult GetAll() {
            var result = _context.Bookings.ToList();

            return new JsonResult(result);
        }
    }
}
