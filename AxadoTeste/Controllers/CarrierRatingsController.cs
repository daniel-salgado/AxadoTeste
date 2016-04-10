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

    public class CarrierRatingsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: CarrierRatings
        public ActionResult Index()
        {

            if (Session["id_User"] != null)
            {


                int _user = int.Parse(Session["id_User"].ToString());

                var carrierRating = db.CarrierRating.Include(c => c.Carrier).Include(c => c.User).Where(x => x.id_User == _user);


                return View(carrierRating.ToList());
            }
            else
            {

                return RedirectToAction("Index", "Home");

            }




        }

        // GET: CarrierRatings/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierRating carrierRating = db.CarrierRating.Find(id);
            if (carrierRating == null)
            {
                return HttpNotFound();
            }
            return View(carrierRating);
        }

        // GET: CarrierRatings/Create
        public ActionResult Create()
        {

            int _user = int.Parse(Session["id_User"].ToString());

            ViewBag.id_Carrier = new SelectList(db.Carrier, "id", "Name");

            ViewBag.id_User = new SelectList(db.User.Where(x => x.id == _user), "id", "UserName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_Carrier,id_User,Rating")] CarrierRating _newCarrierRating)
        {

            var extCarrierRating = db.CarrierRating.Where(x => x.id_Carrier == _newCarrierRating.id_Carrier && x.id_User == _newCarrierRating.id_User).FirstOrDefault();

            if (ModelState.IsValid)
            {

                //if (db.CarrierRating.Count(x => x.id_Carrier == carrierRating.id_Carrier && x.id_User == carrierRating.id_User) == 0)
                if (extCarrierRating == null)
                {

                    db.CarrierRating.Add(_newCarrierRating);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {




                    return RedirectToAction("Edit", new RouteValueDictionary(new { controller = "CarrierRatings", action = "Edit", Id = extCarrierRating.id }));
                }


            }

            ViewBag.id_Carrier = new SelectList(db.Carrier, "id", "Name", _newCarrierRating.id_Carrier);
            ViewBag.id_User = new SelectList(db.User, "id", "UserName", _newCarrierRating.id_User);
            return View(_newCarrierRating);
        }

        // GET: CarrierRatings/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierRating carrierRating = db.CarrierRating.Find(id);
            if (carrierRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Carrier = new SelectList(db.Carrier, "id", "Name", carrierRating.id_Carrier);
            ViewBag.id_User = new SelectList(db.User, "id", "UserName", carrierRating.id_User);
            return View(carrierRating);
        }

        // POST: CarrierRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_Carrier,id_User,Rating")] CarrierRating carrierRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrierRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Carrier = new SelectList(db.Carrier, "id", "Name", carrierRating.id_Carrier);
            ViewBag.id_User = new SelectList(db.User, "id", "UserName", carrierRating.id_User);
            return View(carrierRating);
        }

        // GET: CarrierRatings/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierRating carrierRating = db.CarrierRating.Find(id);
            if (carrierRating == null)
            {
                return HttpNotFound();
            }
            return View(carrierRating);
        }

        // POST: CarrierRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CarrierRating carrierRating = db.CarrierRating.Find(id);
            db.CarrierRating.Remove(carrierRating);
            db.SaveChanges();
            return RedirectToAction("Index");
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
