using System;
using launchpadApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace launchpadApp.Controllers {

    public class HomeController : Controller {

        private LinkManager linkManager;

        public HomeController(LinkManager myManager) {
            linkManager = myManager;
        }

        public IActionResult Index() {
            return View(linkManager);            
        }

        // public IActionResult Add() {
        //     // construct Customer object that will be used to add a new customer
        //     Customer customer = new Customer();
        //     // pass it into the view for populating
        //     return View(customer);
        // }

        // [HttpPost]
        // public IActionResult AddSubmit(Customer customer) {
        //     if (!ModelState.IsValid) return RedirectToAction("index");
            
        //     // take form data and create new customer in DB
        //     customerManager.Add(customer);
        //     customerManager.SaveChanges();

        //     // following PRG pattern
        //     return RedirectToAction("index");
        // }

        // public IActionResult Delete() {
        //     Customer customer = new Customer();

        //     ViewBag.selectList = customerManager.getSelectList();
        //     // ViewData["selectList"] = "whatever";

        //     return View(customer);
        // }

        // [HttpPost]
        // public IActionResult DeleteSubmit(Customer customer) {
        //     customerManager.Remove(customer);
        //     customerManager.SaveChanges();

        //     return RedirectToAction("index");
        // }

        // // -- > UPDATE Challenge 

        // public IActionResult Update(Customer customer) {
        //     ViewBag.selectList = customerManager.getSelectList();
        //     // ViewBag.firstName = customer.firstName;
        //     if (customer.customerID == 0) customer = customerManager.customers[0];
        //     return View("Update", customer);
        // }

        // public IActionResult UpdateSelect(Customer customer) {
        //         customer = customerManager.customers.Find(c => c.customerID == customer.customerID);
        //     return RedirectToAction("Update", customer);
        // }

        // [HttpPost]
        // public IActionResult UpdateSubmit(Customer customer) {
        //    customerManager.Update(customer);
        //    customerManager.SaveChanges();

        //     return RedirectToAction("Index");
        // }
    }
}
