using System;
using launchpadApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace launchpadApp.Controllers {

    public class AdminController : Controller {

        private Manager manager;

        public AdminController(Manager myManager) {
            manager = myManager;
        }

        public IActionResult Index() {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            return View(manager);            
        }   
 
        // -------------------------------- ADD CATEGORY LINK
        public IActionResult AddLink(string category, string categoryName) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            // get categories list
            ViewBag.SelectList = manager.getCategoryList();
            // construct Link object that will be used to add a new link
            Link link = new Link();
            // set category ID to the one clicked
            link.categoryID = Convert.ToInt32(category);
            link.linkName = categoryName;
            // pass it into the view for populating
            return View(link);
        }
 
        [HttpPost] 
        public IActionResult AddLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            // data validation
            if (!ModelState.IsValid) return RedirectToAction("index");
            // Add Link object to manager and save
            manager.Add(link);
            manager.SaveChanges();
            return RedirectToAction("Index");
        }

        // --------------------------------  EDIT CATEGORY
        public IActionResult EditCategory(int id) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            Category category =  manager.getCategoryByID(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategorySubmit(Category category) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            // data validation
            if (!ModelState.IsValid) return RedirectToAction("index");
            manager.Update(category);
            manager.SaveChanges();
            return RedirectToAction("Index");
        }
         
        // -------------------------------- EDIT LINK
        public IActionResult EditLink(int id) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            // get links list
            ViewBag.SelectList = manager.getCategoryList();
            Link link = manager.getLinkByID(id);
            return View(link);
        }

        [HttpPost]             
        public IActionResult EditLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }      
            // data validation
            if (!ModelState.IsValid) return RedirectToAction("index");
            manager.Update(link);
            manager.SaveChanges();
            return RedirectToAction("Index");
        }

        // -------------------------------- DELETE LINK
        public IActionResult DeleteLink(int id) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            Link link = manager.getLinkByID(id);
            return View(link);
        }

        [HttpPost]
        public IActionResult DeleteLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            manager.Remove(link);
            manager.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
