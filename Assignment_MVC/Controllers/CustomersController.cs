using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_MVC.Models;

namespace Assignment_MVC.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.Services
                          select new
                          {
                              b.ServiceID,
                              b.ServiceName,
                              Checked = ((from ab in db.CustomerToServices
                                          where (ab.ServiceID == id) & (ab.ServiceID == b.ServiceID)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new CustomerViewModel();

            MyViewModel.CustomerID = id.Value;
            MyViewModel.Name = customer.Name;
            MyViewModel.Email = customer.Email;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.ServiceID, Name = item.ServiceName, Checked = item.Checked });
            }
            MyViewModel.SevicesLists = MyCheckBoxList;

            return View(MyViewModel);
          
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.Services
                          select new
                          {
                              b.ServiceID,
                              b.ServiceName,
                              Checked = ((from ab in db.CustomerToServices
                                          where (ab.ServiceID == id) & (ab.ServiceID == b.ServiceID)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new CustomerViewModel();

            MyViewModel.CustomerID = id.Value;
            MyViewModel.Name = customer.Name;
            MyViewModel.Email = customer.Email;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach(var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id= item.ServiceID, Name = item.ServiceName, Checked = item.Checked });
            }
            MyViewModel.SevicesLists = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var MyCustomer = db.Customers.Find(customer.CustomerID);

                MyCustomer.Name = customer.Name;
                MyCustomer.Email = customer.Email;
                
                foreach( var item in db.CustomerToServices)
                {
                    if(item.CustomerID == customer.CustomerID)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach(var item in customer.SevicesLists)
                {
                    if(item.Checked)
                    {
                        db.CustomerToServices.Add(new CustomerToService() { CustomerID = customer.CustomerID, ServiceID = item.Id });
                    }
                }
         
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
