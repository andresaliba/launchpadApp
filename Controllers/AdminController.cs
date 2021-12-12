using System;
using launchpadApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace launchpadApp.Controllers {

    public class AdminController : Controller {

        private CategoryManager categoryManager;
        private LinkManager linkManager;

        public AdminController(CategoryManager myManager) {
            categoryManager = myManager;
        }

        public IActionResult Index() {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            return View(categoryManager);            
        }

        // -------------------------------- ADD LINK
        public IActionResult AddLink(string name, int id) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            // construct Link object that will be used to add a new link
            Link link = new Link();
            // pass it into the view for populating
            return View(link);
        }

        [HttpPost]
        public IActionResult AddLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            categoryManager.Add(link);
            categoryManager.SaveChanges();
            return RedirectToAction("Index");
        }

        // --------------------------------  EDIT CATEGORY
        public IActionResult EditCategory(string name, int id) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
           Category category = new Category();
           category.categoryID = id;
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategorySubmit(Category category) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            categoryManager.Update(category);
            categoryManager.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // -------------------------------- EDIT LINK
        public IActionResult EditLink(string name, int id) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
           Category category = new Category();
           category.categoryID = id;
            return View(category);
        }

        [HttpPost]
        public IActionResult EditLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            categoryManager.Update(link);
            categoryManager.SaveChanges();
            return RedirectToAction("Index");
        }

        // -------------------------------- DELETE LINK
        public IActionResult DeleteLink(string name, int id, string url) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
           Link link  = new Link();
           link.name = name;
           link.id = id;
           link.url = url;
            return View(link);
        }

        [HttpPost]
        public IActionResult DeleteLinkSubmit(Link link) {
            if (HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index","Login");
            }
            linkManager.Remove(link);
            linkManager.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
