using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AxadoTeste.Models;
using System.Web.Routing;

namespace AxadoTeste.Controllers
{
    public class CarrierController : Controller
    {
        private dbContext db = new dbContext();
        private object httpContext;

        // GET: Carrier
        public ActionResult Index()
        {
            return View(db.Carrier.ToList());
        }

        // GET: Carrier/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carrier.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // GET: Carrier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Phone,Adress,City,State")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Carrier.Add(carrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrier);
        }

        // GET: Carrier/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carrier.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carrier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Phone,Adress,City,State")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrier);
        }

        // GET: Carrier/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carrier.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carrier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {

            try
            {
                Carrier carrier = db.Carrier.Find(id);
                db.Carrier.Remove(carrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

                return RedirectToAction("SomeError", new RouteValueDictionary(new { controller = "Carrier", action = "SomeError", message = error.Message.ToString() }));
            }

        }

        public ActionResult SomeError(string message)
        {
            ViewBag.message = message;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
