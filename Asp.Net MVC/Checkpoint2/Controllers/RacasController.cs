
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Checkpoint2.Context;
using Checkpoint2.Models;

namespace Checkpoint2.Controllers
{
    public class RacasController : Controller
    {
        private Context.Context db = new Context.Context();

        // GET: Racas
        public ActionResult Index()
        {
            return View(db.Racas1.ToList());
        }

        // GET: Racas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racas racas = db.Racas1.Find(id);
            if (racas == null)
            {
                return HttpNotFound();
            }
            return View(racas);
        }

        // GET: Racas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Racas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRaca,Raca")] Racas racas)
        {
            if (ModelState.IsValid)
            {
                db.Racas1.Add(racas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(racas);
        }

        // GET: Racas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racas racas = db.Racas1.Find(id);
            if (racas == null)
            {
                return HttpNotFound();
            }
            return View(racas);
        }

        // POST: Racas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRaca,Raca")] Racas racas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(racas);
        }

        // GET: Racas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racas racas = db.Racas1.Find(id);
            if (racas == null)
            {
                return HttpNotFound();
            }
            return View(racas);
        }

        // POST: Racas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racas racas = db.Racas1.Find(id);
            db.Racas1.Remove(racas);
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
