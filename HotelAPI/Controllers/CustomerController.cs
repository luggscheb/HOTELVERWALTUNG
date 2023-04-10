using Hotel;
using HotelAPI.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelAPI.Controllers
{
   
        [ApiController]
        [Route("api/hotel")]
        public class CustomerController : ControllerBase
        {
            private Hotel_Context _context;

            public CustomerController(Hotel_Context context)
            {
                this._context = context;
            }

            [HttpGet]
            [Route("customer")]
            public IActionResult AllArticles()
            {
                //Die Artikellisten zu Json konvertieren
                return new JsonResult(this._context.Customers.ToList<Customer>());
            }

            [HttpPost]
            [Route("newcustomer")]
            public async Task<IActionResult> PutNewCustomer(Customer customer)
            {
                if (customer == null)
                {
                    return new JsonResult(false);
                }

                this._context.Customers.Add(customer);

                int result = await this._context.SaveChangesAsync();
                return new JsonResult(result == 1);
            }
        }
    }

