using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservationApplication.Models;

namespace ReservationApplication.Controllers
{
    public class UserController : Controller
    {
      
        BusReservationEntities db = new BusReservationEntities();
        // GET: User
        public ActionResult SelectBus()
        {
            ViewData["ListItem"] = new List<SelectBusListModel>();
            return View();
        }
        [HttpPost]
        public ActionResult SelectBus(SelectBusModel model)
        {
            List<ScheduleDetails> schedule = db.ScheduleDetails.ToList();
            List<SelectBusListModel> ObjItem = new List<SelectBusListModel>();
            
            foreach (ScheduleDetails ele in schedule)
            {
                if (ele.Origin == model.Origin && ele.Destination == model.Destination && ele.Date == model.Date)
                {
                    ObjItem.Add(new SelectBusListModel
                    {
                        BusId = ele.BusId,
                        ScheduleId  = ele.ScheduleId,
                        BusType = db.BusDetails.Single(x => x.BusId == ele.BusId).BusType,
                        AvailableSeats = ele.AvailableSeats,
                        DepartTime = ele.DepartTime
                    });
                }
            }
            ViewData["ListItem"] = ObjItem;

            return View();

             
        
        }

    }
}