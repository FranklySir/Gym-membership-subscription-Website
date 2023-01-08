using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapStone.Models;
using System.Data.Entity;

namespace CapStone.Controllers
{
    public class ClassController : Controller
    {
        private Classes slot = new Classes();
        // GET: Class
        public ActionResult Index()
        {
            return View(slot.Class.ToList());
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            Class item = slot.Class.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            var getclass = slot.Class.ToList();
            SelectList list = new SelectList(getclass, "Id", "Class1");
            ViewBag.SelectClass = list;
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Class newMember)
        {
            try
            {
                // TODO: Add insert logic here
                slot.Class.Add(newMember);
                slot.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            Class item = slot.Class.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(Class NewMember)
        {
            try
            {
                // TODO: Add update logic here
                slot.Entry(NewMember).State = EntityState.Modified;
                slot.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            Class item = slot.Class.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Class item = slot.Class.Find(id);
                slot.Class.Remove(item);
                slot.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
