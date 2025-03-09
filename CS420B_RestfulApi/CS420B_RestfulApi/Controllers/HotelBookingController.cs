using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Models.Table;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using CS420B_RestfulApi.Models.InputModule;


namespace CS420B_RestfulApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly IBooking _context;

        public HotelBookingController(IBooking context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public JsonResult GetAll() {
            try
            {
                return new JsonResult(Ok(_context.GetAll()));
            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }

        [HttpGet("{id}")]
        public JsonResult GetById(Guid id)
        {
            try
            {
                var data = _context.GetById(id);
                if (data != null)
                {
                    return new JsonResult(Ok(data));
                }
                else { return new JsonResult(NotFound()); }
            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }

        //Create
        [HttpPost]
        public JsonResult Create(BookingModule bookingModule)
        {
            try
            {
                return new JsonResult(Ok(_context.Add(bookingModule)));
            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public JsonResult Delete(Guid id)
        {
            try
            {
                _context.Delete(id);
                return new JsonResult(Ok());
            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }

        //Update
        [HttpPut("{id}")]
        public JsonResult Update(BookingVM booking)
        {
            try
            {
                _context.Update(booking);
                return new JsonResult(Ok());

            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }
    }
}
