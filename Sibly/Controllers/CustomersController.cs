using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Sibly.Models;
using Sibly.ViewModels;

namespace Sibly.Controllers
{
    public class CustomersController : Controller
    {

        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        //GET: /Customers/
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }



               //GET: /Customers/
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }



         //GET: /Customers/
        [HttpPost]
        public ActionResult Create(Customer Customers)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes.ToList();

                if (Customers.CustomerId==0)
                {

                    var viewModele = new CustomerFormViewModel()
                    {

                        MembershipTypes = membershipTypes

                    };
                    return View("CustomerForm", viewModele); 
                }




                var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == Customers.CustomerId);
               

                var viewModel = new CustomerFormViewModel(customer)
                {

                    MembershipTypes = membershipTypes

                };
                return View("CustomerForm", viewModel);
            }

 
            if (Customers.CustomerId == 0)
                {
                    _context.Customers.Add(Customers);
                }
                else
                {
                    var curcustomer = _context.Customers.Single(c => c.CustomerId == Customers.CustomerId);
                    curcustomer.Birthdate = Customers.Birthdate;
                    curcustomer.Name = Customers.Name;
                    curcustomer.MembershipTypeId = Customers.MembershipTypeId;
                    curcustomer.isSubscribedToNewsletter = Customers.isSubscribedToNewsletter;
                };
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        
       







        public ActionResult Edit(int id)
        {

            var customer = _context.Customers.Single(c => c.CustomerId == id);
            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }



        //
         //GET: /Customers/
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
	}
}