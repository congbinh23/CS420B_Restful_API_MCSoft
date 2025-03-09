using CS420B_RestfulApi.Models.InputModule;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS420B_RestfulApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoom _context;

        public RoomController(IRoom context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public JsonResult GetAll()
        {
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
        public JsonResult GetById(int id)
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
        public JsonResult Create(RoomModule roomModule)
        {
            try
            {
                return new JsonResult(Ok(_context.Add(roomModule)));
            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
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
        [HttpPut("{RoomNumber}")]
        public JsonResult Update(RoomVM roomVM)
        {
            try
            {
                _context.Update(roomVM);
                return new JsonResult(Ok());

            }
            catch
            {
                return new JsonResult(BadRequest());
            }
        }
    }
}
