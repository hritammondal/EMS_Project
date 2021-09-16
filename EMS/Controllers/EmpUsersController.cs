using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;

namespace EMS.Controllers
{
    public class EmpUsersController : Controller
    {
        private EMSEntities1 db = new EMSEntities1();

        // GET: EmpUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.EmpUsers.ToListAsync());
        }

        // GET: EmpUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpUser empUser = await db.EmpUsers.FindAsync(id);
            if (empUser == null)
            {
                return HttpNotFound();
            }
            return View(empUser);
        }

        // GET: EmpUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,Name,EmailID,Password")] EmpUser empUser)
        {
            if (ModelState.IsValid)
            {
                db.EmpUsers.Add(empUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(empUser);
        }

        // GET: EmpUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpUser empUser = await db.EmpUsers.FindAsync(id);
            if (empUser == null)
            {
                return HttpNotFound();
            }
            return View(empUser);
        }

        // POST: EmpUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,Name,EmailID,Password")] EmpUser empUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(empUser);
        }

        // GET: EmpUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpUser empUser = await db.EmpUsers.FindAsync(id);
            if (empUser == null)
            {
                return HttpNotFound();
            }
            return View(empUser);
        }

        // POST: EmpUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmpUser empUser = await db.EmpUsers.FindAsync(id);
            db.EmpUsers.Remove(empUser);
            await db.SaveChangesAsync();
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
