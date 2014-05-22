using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Bootstrap;

namespace MVC_Bootstrap.Controllers
{
    public class ClientController : Controller
    {
        private RFAEntities db = new RFAEntities();

        // GET: /Client/
        public async Task<ActionResult> Index()
        {
            var clients = db.Clients.Take(100).Include(c => c.Employer);
            return View(await clients.ToListAsync());
        }

        // GET: /Client/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: /Client/Create
        public ActionResult Create()
        {
            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Description");
            return View();
        }

        // POST: /Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ClientID,Firstname,Surname,Initials,EmployeeNumber,IDPassport,ContractorNo,Street,Block,City,Country,PostalCode,ContactNo,EthnicalGroupID,DOB,GenderID,RegistrationDate,EmployerID,CreatedByID,ModifiedByID,ModifiedDate,CreatedDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Description", client.EmployerID);
            return View(client);
        }

        // GET: /Client/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Description", client.EmployerID);
            return View(client);
        }

        // POST: /Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ClientID,Firstname,Surname,Initials,EmployeeNumber,IDPassport,ContractorNo,Street,Block,City,Country,PostalCode,ContactNo,EthnicalGroupID,DOB,GenderID,RegistrationDate,EmployerID,CreatedByID,ModifiedByID,ModifiedDate,CreatedDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Description", client.EmployerID);
            return View(client);
        }

        // GET: /Client/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
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
