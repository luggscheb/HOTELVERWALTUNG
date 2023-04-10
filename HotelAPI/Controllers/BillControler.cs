using Hotel;
using HotelAPI.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/hotel")]
    public class BillControler : ControllerBase
    {
        private Hotel_Context _context;

        public BillControler(Hotel_Context context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("bills")]
        public IActionResult AllBills()
        {
            //Die Artikellisten zu Json konvertieren
            return new JsonResult(this._context.Billsroom.ToList<BillRoom>());
        }

        [HttpPost]
        [Route("newBill")]
        public async Task<IActionResult> PutNewBill(BillRoom bill)
        {
            if (bill == null)
            {
                return new JsonResult(false);
            }

            
            
            if(this._context.Billsroom.Find(bill.CustomerId) != null )
            {

                var neuS = bill.StartDate;
                var resS = this._context.Billsroom.Find(bill.RoomId).StartDate;
                var neuE = bill.EndDate;
                var resE = this._context.Billsroom.Find(bill.RoomId).EndDate;
                if((neuS >= resS && neuS <= resS)||(neuE >= resE && neuE <= resE))
                {
                    return new JsonResult(false);
                }
            }

            if(this._context.Billsroom.Find(bill.CustomerId) != null)
            {
                var neuS = bill.StartDate;
                var resS = this._context.Billsroom.Find(bill.CustomerId).StartDate;
                var neuE = bill.EndDate;
                var resE = this._context.Billsroom.Find(bill.CustomerId).EndDate;
                if ((neuS >= resS && neuS <= resS) || (neuE >= resE && neuE <= resE))
                {
                    return new JsonResult(false);
                }
            }
            

            this._context.Billsroom.Add(bill);

            int result = await this._context.SaveChangesAsync();
            return new JsonResult(result == 1);
        }

        [HttpDelete]
        [Route("removeBill")]
        public async Task<IActionResult> DeleteBill(int billId)
        {


            _ = this._context.Billsroom.Remove(this._context.Billsroom.Find(billId));

            int result = await this._context.SaveChangesAsync();
            return new JsonResult(result == 1);
        }
    }
}
