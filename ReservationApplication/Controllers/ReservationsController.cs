using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservationApplication.Models;
namespace ReservationApplication.Controllers
{
    public class ReservationsController : Controller
    {
        BusReservationEntities db = new BusReservationEntities();

        // GET: Reservations
        public ActionResult Reservations()
        {
            List<BookingDetails> booking = new List<BookingDetails>();
            int regId;

            if (db.UserDetail.Single(x => x.EmailId == User.Identity.Name).Role.ToLower() != "Admin")
            {
                regId = db.UserDetail.Single(x => x.EmailId == User.Identity.Name).RegId;
                booking = (from bd in db.BookingDetails where bd.RegId == regId select bd).ToList();
            }
            else
            {
                booking = db.BookingDetails.ToList();
            }

            List<ReservationsModel> reservations = new List<ReservationsModel>();
            foreach (var item in booking)
            {
                ReservationsModel res = new ReservationsModel();
                res.bookingDetails = item;
                res.busDetails = db.BusDetails.Single(x => x.BusId == item.BusId);
                res.scheduleDetails = db.ScheduleDetails.Single(x => x.ScheduleId == item.Schedule);

                reservations.Add(res);
            }

            return View();
        }
    }
}