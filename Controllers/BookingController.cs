using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapStone.Models;
using System.Data.Entity;

namespace CapStone.Controllers
{
    public class BookingController : Controller
    {
        private Book booking = new Book();
        private Classes db =  new Classes();
        // GET: Booking
        public ActionResult Index()
        {
            return View(booking.Bookings.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {

            var getclass = db.Class.ToList();
            SelectList list = new SelectList(getclass, "Id", "Class1");
            ViewBag.SelectClass = list;
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Booking newMember)
        {
            try
            {
                // TODO: Add insert logic here
                booking.Bookings.Add(newMember);
                booking.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
