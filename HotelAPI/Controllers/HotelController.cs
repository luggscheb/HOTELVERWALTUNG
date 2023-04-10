using Microsoft.AspNetCore.Mvc;
using HotelAPI.Models.DB;
using Hotel;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/hotel")]
    public class HotelController : ControllerBase
    {
        private Hotel_Context _context;

        public HotelController(Hotel_Context context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("rooms")]
        public IActionResult AllArticles()
        {
            //Die Artikellisten zu Json konvertieren
            return new JsonResult(this._context.Rooms.ToList<Room>());
        }

        [HttpPost]
        [Route("newroom")]
        public async Task<IActionResult> PutNewRoom(Room room)
        {
            if (room == null)
            {
                return new JsonResult(false);
            }

            this._context.Rooms.Add(room);

            int result = await this._context.SaveChangesAsync();
            return new JsonResult(result == 1);
        }
    }
}